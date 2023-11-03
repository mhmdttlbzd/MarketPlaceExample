using MarketPlace.Domain.Core.Identity.Contract;
using MarketPlace.Endpoint.Mvc.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace MarketPlace.Endpoint.Mvc.Controllers
{
    public class Account : Controller
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public Account(IAuthenticationAppService authenticationAppService)
        {
            _authenticationAppService = authenticationAppService;
        }

        public IActionResult Login()
        {
            
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationAppService.Login(model.Email, model.Password);
                if (result.Succeeded)
                {
                    
                    return LocalRedirect("/Home/");
                }

                ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه است *");
            }
            return View("Login");
        }
    }
}
