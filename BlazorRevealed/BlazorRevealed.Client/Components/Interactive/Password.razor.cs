using System;
using System.Threading.Tasks;
using BlazorRevealed.Client.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class PasswordBase : Component
    {
        protected bool ShowPassword;

        [Parameter]
        public string Password { get; set; }

        [Parameter]
        public EventCallback<string> PasswordChanged { get; set; }

        protected Task OnPasswordChanged(ChangeEventArgs e)
        {
            Password = e.Value.ToString();
            return PasswordChanged.InvokeAsync(Password);
        }

        protected void ToggleShowPassword()
        {
            ShowPassword = !ShowPassword;
        }
    }
}