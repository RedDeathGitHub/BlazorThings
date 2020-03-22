using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Components.Interactive;
using BlazorRevealed.Client.Data.Models;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services.I;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class RegisterPageBase : Page
    {
        [Inject]
        protected IAuthService AuthService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected Registration Registration = new Registration();
        protected bool ShowErrors;
        protected IEnumerable<string> Errors;

        protected async Task HandleRegistration()
        {
            ShowErrors = false;

            var result = await AuthService.Register(Registration);

            if (result.Successful)
            {
                NavigationManager.NavigateTo("/login");
            }
            else
            {
                Errors = result.Errors;
                ShowErrors = true;
            }
        }
    }
}