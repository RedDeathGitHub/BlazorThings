using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorRevealed.Client.Constants;
using BlazorRevealed.Client.Infrastructure;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApiClient apiClient;
        private readonly ApiAuthenticationStateProvider authenticationStateProvider;
        private readonly ILocalStorageService localStorage;

        public AuthService(ApiClient apiClient,
            ApiAuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            this.apiClient = apiClient;
            this.authenticationStateProvider = authenticationStateProvider;
            this.localStorage = localStorage;
        }

        public async Task<RegistrationResult> Register(Registration registration)
        {
            var result = await apiClient.PostJsonAsync<RegistrationResult>("accounts", registration);

            return result;
        }

        public async Task<LoginResult> Login(Login login)
        {
            var loginAsJson = JsonSerializer.Serialize(login);
            var response = await apiClient.PostAsync("login",
                new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await authenticationStateProvider.Login(loginResult.Token);
            return loginResult;
        }

        public async Task Logout()
        {
            await authenticationStateProvider.Logout();
        }

        public async Task Update()
        {
            await authenticationStateProvider.UpdateUser();
        }
    }
}