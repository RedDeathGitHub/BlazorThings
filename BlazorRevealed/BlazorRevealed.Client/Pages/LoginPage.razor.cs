using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class LoginPageBase : Page
    {
        [Inject]
        protected IAuthService AuthService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected Login Login = new Login();
        protected bool ShowErrors;
        protected string Error;

        protected async Task HandleLogin()
        {
            ShowErrors = false;

            var result = await AuthService.Login(Login);

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Error = result.Error;
                ShowErrors = true;
            }
        }
    }
}