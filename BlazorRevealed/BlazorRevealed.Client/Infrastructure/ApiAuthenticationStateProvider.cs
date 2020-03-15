using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorRevealed.Client.Utility.HttpClients;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRevealed.Client.Infrastructure
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ApiClient apiClient;
        private readonly ILocalStorageService _localStorage;

        public ApiAuthenticationStateProvider(ApiClient apiClient, ILocalStorageService localStorage)
        {
            this.apiClient = apiClient;
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            apiClient.DefaultRequestHeaders.Authorization = null;

            var tokenValue = await _localStorage.GetItemAsync<string>("authToken");

            if (string.IsNullOrWhiteSpace(tokenValue))
            {
                return LogOut();
            }

            var token = ParseJwtToken(tokenValue);

            if (DateTime.UtcNow >= token.Expires)
            {
                return LogOut();
            }

            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", tokenValue);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(token.Claims, "serverauth")));
        }

        private AuthenticationState LogOut()
        {
            var unauthenticatedUser = new ClaimsPrincipal(new ClaimsIdentity());
            MarkUserAsLoggedOut();
            return new AuthenticationState(unauthenticatedUser);
        }

        public void MarkUserAsAuthenticated(string email)
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
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
