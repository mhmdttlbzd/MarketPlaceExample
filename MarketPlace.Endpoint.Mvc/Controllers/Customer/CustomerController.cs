using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Customer
{
    public class CustomerController : Controller
    {
        private readonly IAdminPanelAppService _adminPanelAppService;
        private readonly ICustomerAppService _customerAppService;
        public CustomerController(IAdminPanelAppService adminPanelAppService, ICustomerAppService customerAppService)
        {
            _adminPanelAppService = adminPanelAppService;
            _customerAppService = customerAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreatePost(GeneralCustomerInputDto input, CancellationToken cancellationToken)
        {
            await _adminPanelAppService.CreateCustomer(input, cancellationToken);
            return LocalRedirect("/Admin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var res = await _customerAppService.GetById(id);
            return View(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditPost(GeneralCustomerInputDto input, CancellationToken cancellationToken)
        {
            await _customerAppService.UpdateCustomer(input, cancellationToken);
            return LocalRedirect("/Admin");
        }


    }
}
