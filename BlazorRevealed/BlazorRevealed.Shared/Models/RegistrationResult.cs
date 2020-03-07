using System.Collections.Generic;

namespace BlazorRevealed.Shared.Models
{
    public class RegistrationResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
