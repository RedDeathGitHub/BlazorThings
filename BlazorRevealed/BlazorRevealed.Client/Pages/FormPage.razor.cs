using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Components.Interactive;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Utility.HttpClients;
using BlazorRevealed.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class FormPageBase : ComponentBase
    {
        [Inject]
        public State State { get; set; }

        public bool Selected { get; set; }

        public string Text { get; set; } = "Type here";

        public double Number { get; set; } = 10;

        public string Password { get; set; }

        protected Password PasswordComponent { get; set; }

        protected void SetPassword()
        {
            Password += "X";
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            var value = PasswordComponent.Password + "R";
            if (firstRender)
            {
                value += "first";
            }
                        
            Password = value;
        }
    }
}