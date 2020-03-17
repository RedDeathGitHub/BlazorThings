using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorRevealed.Client.Constants;
using BlazorRevealed.Client.Utility.HttpClients;
using FluentScheduler;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRevealed.Client.Infrastructure
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ApiClient apiClient;
        private readonly ILocalStorageService localStorage;
        readonly ClaimsPrincipal AnonymousUser = new ClaimsPrincipal(new ClaimsIdentity());

        public ApiAuthenticationStateProvider(ApiClient apiClient, ILocalStorageService localStorage)
        {
            this.apiClient = apiClient;
            this.localStorage = localStorage;
        }
        
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await GetUser();
            return new AuthenticationState(user);
        }

        public async Task UpdateUser()
        {
            var user = await GetUser();

            var authState = Task.FromResult(new AuthenticationState(user));
            NotifyAuthenticationStateChanged(authState);
        }

        private async Task<ClaimsPrincipal> GetUser()
        {
            apiClient.DefaultRequestHeaders.Authorization = null;
            var tokenValue = await localStorage.GetItemAsync<string>(Keys.AuthToken);

            if (string.IsNullOrWhiteSpace(tokenValue))
            {
                return AnonymousUser;
            }

            var token = ParseJwtToken(tokenValue);

            if (DateTime.UtcNow >= token.Expires)
            {
                await localStorage.RemoveItemAsync(Keys.AuthToken);
                return AnonymousUser;
            }

            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenValue);
            ScheduleLogout(token.Expires);
            return new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "serverauth"));
        }

        private void ScheduleLogout(DateTime tokenExpires)
        {
            Console.WriteLine($"Scheduling logout at {tokenExpires}");

            JobManager.AddJob(async () => await Logout(), s => s.WithName(Jobs.Logout).ToRunOnceAt(tokenExpires));
        }

        public async Task Login(string token)
        {
            Console.WriteLine("Logging in");

            await localStorage.SetItemAsync(Keys.AuthToken, token);
            await UpdateUser();
        }

        public async Task Logout()
        {
            JobManager.RemoveJob(Jobs.Logout);

            Console.WriteLine("Logging out");

            await localStorage.RemoveItemAsync(Keys.AuthToken);
            await UpdateUser();
        }

        private JwtToken ParseJwtToken(string tokenValue)
        {
            var token = new JwtToken();
            var payload = tokenValue.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"Key is {item.Key} Value is {item.Value}");
            }

            var seconds = Convert.ToInt32(keyValuePairs["exp"].ToString());
            var date = DateTimeOffset.FromUnixTimeSeconds(seconds).UtcDateTime;

            Console.WriteLine($"Expire date: {date}");

            token.Expires = date;

            keyValuePairs.TryGetValue(ClaimTypes.Role, out object roles);

            if (roles != null)
            {
                if (roles.ToString().Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                    foreach (var parsedRole in parsedRoles)
                    {
                        token.Claims.Add(new Claim(ClaimTypes.Role, parsedRole));
                    }
                }
                else
                {
                    token.Claims.Add(new Claim(ClaimTypes.Role, roles.ToString()));
                }

                keyValuePairs.Remove(ClaimTypes.Role);
            }

            token.Claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));

            return token;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
    }

    class JwtToken
    {
        public List<Claim> Claims { get; set; } = new List<Claim>();
        public DateTime Expires { get; set; }
    }
}
