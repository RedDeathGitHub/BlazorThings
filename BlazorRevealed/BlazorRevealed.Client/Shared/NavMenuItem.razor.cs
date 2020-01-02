using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorRevealed.Client.Shared
{
    public class NavMenuItemBase : ComponentBase
    {
        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; }
    }
}