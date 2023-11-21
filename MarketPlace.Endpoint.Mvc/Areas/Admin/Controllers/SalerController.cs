using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SalerController : Controller
    {
        private readonly IAdminPanelAppService _adminPanelAppService;
        private readonly ISellerAppService _salerAppService;

        public SalerController(IAdminPanelAppService adminPanelAppService, ISellerAppService salerAppService)
        {
            _adminPanelAppService = adminPanelAppService;
            _salerAppService = salerAppService;
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
        public async Task<IActionResult> CreatePost(GeneralSellerInputDto input, CancellationToken cancellationToken)
        {
            await _adminPanelAppService.CreateSaler(input, cancellationToken);
            return LocalRedirect("/Admin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var res = await _salerAppService.GetById(id, cancellationToken);
            return View(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditPost(GeneralSellerInputDto input, CancellationToken cancellationToken)
        {
            await _salerAppService.UpdateSeller(input, cancellationToken);
            return LocalRedirect("/Admin");
        }
    }
}
