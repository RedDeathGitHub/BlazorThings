using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class ClapCounterBase : ComponentBase
    {
        [Parameter]
        public int Claps { get; set; }

        [Parameter]
        public EventCallback AddClap { get; set; }
    }
}