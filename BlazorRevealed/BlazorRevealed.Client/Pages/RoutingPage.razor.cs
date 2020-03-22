using BlazorRevealed.Client.Base;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Pages
{
    public class RoutingPageBase : Page
    {
        [Parameter]
        public int Parameter { get; set; }
    }
}