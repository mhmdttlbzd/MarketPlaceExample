using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Identity.Contract;
using MarketPlace.Endpoint.Mvc.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace MarketPlace.Endpoint.Mvc.Controllers
{
    public class Account : Controller
    {
        private readonly IAuthenticationAppService _authenticationAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ISellerAppService _sellerAppService;

        public Account(IAuthenticationAppService authenticationAppService, ICustomerAppService customerAppService, ISellerAppService sellerAppService)
        {
            _authenticationAppService = authenticationAppService;
            _customerAppService = customerAppService;
            _sellerAppService = sellerAppService;
        }

        public IActionResult Login()
        {
            throw new Exception();
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

         
        public async Task<IActionResult> Logout()
        {
            await _authenticationAppService.Logout();
			return LocalRedirect("/Home/");
		}

        public IActionResult RegisterAsSeller()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsSeller(GeneralSellerInputDto input,CancellationToken cancellationToken)
        {
            await _sellerAppService.Register(input, cancellationToken);
            return LocalRedirect("~/Home");
        }



        public IActionResult RegisterAsCustomer()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsCustomer(GeneralCustomerInputDto input,CancellationToken cancellationToken)
        {
            await _customerAppService.Register(input, cancellationToken);
            return LocalRedirect("~/Home");
        }




        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
        {
            var res = await _customerAppService.GetDetails(User.Identity.Name, cancellationToken);
            return View(res);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditProfile( CancellationToken cancellationToken)
        {
            var res = await _customerAppService.GetByName(User.Identity.Name, cancellationToken);
            return View(res);
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> EditProfilePost(GeneralCustomerInputDto input, CancellationToken cancellationToken)
        {
            await _customerAppService.UpdateCustomer(input, cancellationToken);
            return RedirectToAction("Profile");
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Deposit(long money)
        {
            await _customerAppService.Deposit(User.Identity.Name, money);
            return RedirectToAction("Profile");
        } 


        
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> BuyCart()
        {
            await _customerAppService.BuyCart(User.Identity.Name);
            return RedirectToAction("Profile");
        }



    }
}
