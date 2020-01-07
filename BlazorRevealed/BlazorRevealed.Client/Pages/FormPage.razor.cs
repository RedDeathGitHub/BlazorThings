using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Components.Interactive;
using BlazorRevealed.Client.Data.Models;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class FormPageBase : ComponentBase
    {
        public FormPageBase()
        {
            Person = new Person();
        }

        [Inject]
        protected State State { get; set; }

        protected Person Person { get; set; }

        protected bool Selected { get; set; }

        protected string Text { get; set; } = "Type here";

        protected double Number { get; set; } = 10;

        protected string Password { get; set; }

        protected Password PasswordComponent { get; set; }

        protected void SetPassword()
        {
            Password += "X";
        }

        //protected override void OnAfterRender(bool firstRender)
        //{
        //    base.OnAfterRender(firstRender);

        //    var value = PasswordComponent.Password + "R";
        //    if (firstRender)
        //    {
        //        value += "first";
        //    }
                        
        //    Password = value;
        //}

        protected void HandleValidSubmit()
        {
            Console.WriteLine("OnValidSubmit");
        }
    }
}