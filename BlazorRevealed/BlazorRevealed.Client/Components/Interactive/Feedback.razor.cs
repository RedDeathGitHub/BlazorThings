using System;
using System.Collections.Generic;
using BlazorRevealed.Client.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class FeedbackBase : Component
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }
    }
}