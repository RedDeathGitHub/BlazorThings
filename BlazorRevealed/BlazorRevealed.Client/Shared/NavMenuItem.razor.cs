using System;
using BlazorRevealed.Client.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace BlazorRevealed.Client.Shared
{
    public class NavMenuItemBase : Component
    {
        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; }
    }
}