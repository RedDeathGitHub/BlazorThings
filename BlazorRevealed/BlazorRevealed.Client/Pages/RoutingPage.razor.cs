using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class RoutingPageBase : ComponentBase
    {
        [Parameter]
        public int Parameter { get; set; }
    }
}