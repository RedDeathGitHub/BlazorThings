﻿using System.ComponentModel.DataAnnotations;

namespace BlazorRevealed.Shared.Models
{
    public class Login
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
