using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class RoutingPageBase : ComponentBase
    {
        [Parameter]
        public string Parameter { get; set; }
    }
}