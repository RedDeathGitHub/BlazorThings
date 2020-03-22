using System;
using System.Collections.Generic;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Components.Interactive.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class TabBase : Component, ITab
    {
        [CascadingParameter]
        public ITabContainer Container { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected string TitleCssClass => Container.ActiveTab == this ? "active" : null;

        protected override void OnInitialized()
        {
            if (Active)
            {
                Container.SetActivateTab(this);
            }
        }

        protected void Activate()
        {
            Container.SetActivateTab(this);
        }
    }
}