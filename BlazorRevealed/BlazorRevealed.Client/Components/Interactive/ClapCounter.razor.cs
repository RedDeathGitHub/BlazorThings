using System;
using BlazorRevealed.Client.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class ClapCounterBase : Component
    {
        [Parameter]
        public int Claps { get; set; }

        [Parameter]
        public EventCallback AddClap { get; set; }
    }
}