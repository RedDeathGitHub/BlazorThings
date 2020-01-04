using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Components.Interactive.Interfaces
{
    public interface ITab
    {
        RenderFragment ChildContent { get; }
    }
}