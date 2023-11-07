using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.AspNetCore.Identity;
using MarketPlace.Domain.Core;
using MarketPlace.Domain.Core.Identity.Entities;
using System.Security.Claims;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Domain.AppServices.Identity
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthenticationAppService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<SignInResult> Login(string username, string password)
        {
            var user = _userManager.FindByNameAsync(username).Result;
            if (user != null && user.Status == UserStatus.Active)
            {
                var result = _userManager.CheckPasswordAsync
                    (user, password).Result;

                if (result)
                {
                    var claim = new Claim(ClaimTypes.Name , username);
                    await _userManager.AddClaimAsync(user, claim);
                    return await _signInManager.PasswordSignInAsync(username, password, true, true);
                }
            }
            return null;
        }
    }
}
