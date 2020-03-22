using System.Security.Claims;
using System.Threading.Tasks;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorRevealed.Client.Base
{
    public class Component : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        [Inject]
        public State State { get; set; }

        protected async Task<ClaimsPrincipal> GetUser()
        {
            var authenticationState = await AuthenticationStateTask;
            return authenticationState.User;
        }
    }
}
