using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class YearControlBase : ComponentBase
    {
        [Parameter]
        public int Year { get; set; }

        [Parameter]
        public EventCallback<int> YearChanged { get; set; }
    }
}