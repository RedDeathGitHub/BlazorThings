using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace BlazorRevealed.Client.Infrastructure
{
    public class JwtToken
    {
        public List<Claim> Claims { get; set; } = new List<Claim>();
        public DateTime Expires { get; set; }
    }
}