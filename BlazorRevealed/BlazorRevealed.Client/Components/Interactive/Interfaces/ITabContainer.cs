using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Components.Interactive.Interfaces
{
    public interface ITabContainer
    {
        ITab ActiveTab { get; }
        void SetActivateTab(ITab tab);
    }
}