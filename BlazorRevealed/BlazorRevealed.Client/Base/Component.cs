using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Shared.Authorization;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRevealed.Client.Base
{
    public abstract class Component : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public State State { get; set; }

        [Inject]
        public IAuthorizationService AuthorizationService { get; set; }

        protected async Task<bool> CheckPolicy(string policy)
        {
            var user = await GetUser();

            var result = await AuthorizationService.AuthorizeAsync(user, policy);

            return result.Succeeded;
        }

        protected async Task<ClaimsPrincipal> GetUser()
        {
            var authenticationState = await AuthenticationStateTask;
            return authenticationState.User;
        }
    }
}
