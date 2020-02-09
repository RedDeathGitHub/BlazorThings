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

        protected void HandleValidSubmit()
        {
            Console.WriteLine("OnValidSubmit");
        }
    }
}