using Microsoft.AspNetCore.Components;

namespace BlazorRevealed.Client.Components
{
    public class YearControlBase : ComponentBase
    {
        [Parameter]
        public int Year { get; set; }

        [Parameter]
        public EventCallback<int> YearChanged { get; set; }
    }
}