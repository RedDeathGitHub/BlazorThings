using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRevealed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private static User LoggedOutUser = new User { IsAuthenticated = false };

        private readonly UserManager<IdentityUser> _userManager;

        public AccountsController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Registration registration)
        {
            var newUser = new IdentityUser { UserName = registration.Email, Email = registration.Email };

            var result = await _userManager.CreateAsync(newUser, registration.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new RegistrationResult { Successful = false, Errors = errors });

            }

            return Ok(new RegistrationResult { Successful = true });
        }
    }
}
