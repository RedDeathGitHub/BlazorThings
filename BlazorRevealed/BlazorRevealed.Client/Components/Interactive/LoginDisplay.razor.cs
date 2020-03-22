using System;
using BlazorRevealed.Client.Base;
using BlazorRevealed.Client.Services.I;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class LoginDisplayBase : Component
    {
        [Inject]
        protected IAuthService AuthService { get; set; }
    }
}