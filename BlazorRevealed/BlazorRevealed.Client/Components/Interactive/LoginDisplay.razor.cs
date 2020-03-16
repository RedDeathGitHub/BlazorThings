using System;
using BlazorRevealed.Client.Services.I;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorRevealed.Client.Components.Interactive
{
    public class LoginDisplayBase : ComponentBase
    {
        [Inject]
        protected IAuthService AuthService { get; set; }
    }
}