using System.Threading.Tasks;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class LogoutPageBase : ComponentBase
    {
        [Inject]
        protected IAuthService AuthService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthService.Logout();
            NavigationManager.NavigateTo("/");
        }
    }
}