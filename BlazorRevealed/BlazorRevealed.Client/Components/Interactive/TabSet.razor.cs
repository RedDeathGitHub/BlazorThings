using BlazorRevealed.Client.Components.Interactive.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class TabSetBase : ComponentBase, ITabContainer
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public ITab ActiveTab { get; private set; }

        public void SetActivateTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                StateHasChanged();
            }
        }
    }
}