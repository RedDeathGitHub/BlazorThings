using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Data.State;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorRevealed.Client.Pages
{
    public class TestPageBase : Page
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }
    }
}