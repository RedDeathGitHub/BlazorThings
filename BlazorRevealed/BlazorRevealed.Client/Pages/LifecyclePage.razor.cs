using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorRevealed.Client.Components.Interactive;
using BlazorRevealed.Client.Data.State;
using BlazorRevealed.Client.Services;
using BlazorRevealed.Client.Utility.HttpClients;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class LifecyclePageBase : ComponentBase, IDisposable
    {
        protected int Index { get; set; } = 1;
        protected string Text { get; set; } = "Initial value\n";

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            Update(nameof(SetParametersAsync));

            await base.SetParametersAsync(parameters);
        }

        protected override void OnInitialized()
        {
            Update(nameof(OnInitialized));
        }

        protected override void OnParametersSet()
        {
            Update(nameof(OnParametersSet));
        }

        protected override void OnAfterRender(bool firstRender)
        {
            Update(nameof(OnAfterRender));
            if (firstRender)
            {
                StateHasChanged();
            }
        }

        private void Update(string eventName)
        {
            var text = $"{Index} {eventName}";
            Index++;
            
            Console.WriteLine(text);
            Text += $"{text}\n";
        }

        public void Dispose()
        {
            Update(nameof(Dispose));
        }
    }
}