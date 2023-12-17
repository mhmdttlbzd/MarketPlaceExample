using MarketPlace.Domain.AppServices.Acount;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Seller;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Areas.Saler.Controllers
{
    [Area("Seller")]
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        private readonly IBoothAppService _boothAppService;
        private readonly ISellerAppService _sellerAppService;
        public SellerController(IBoothAppService boothAppService, ISellerAppService sellerAppService)
        {
            _boothAppService = boothAppService;
            _sellerAppService = sellerAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var res = await _boothAppService.GetBoothPanelInformation(User.Identity.Name, cancellationToken);
            return View(res);
        }
        public async Task<IActionResult> SaledProducts(CancellationToken cancellationToken)
        {
            return View(await _boothAppService.GetSaledProducts(User.Identity.Name, cancellationToken));
        }


        public async Task<IActionResult> EditProfile(CancellationToken cancellationToken)
        {
            var res = await _sellerAppService.GetByName(User.Identity.Name, cancellationToken);
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(GeneralSellerInputDto input, CancellationToken cancellationToken)
        {
            await _sellerAppService.UpdateSeller(input, cancellationToken);
            return LocalRedirect("/");
        }


        public async Task<IActionResult> SellerProducts()
        {
            var res = await _boothAppService.GetSellerProducts(User.Identity.Name);
            return View(res);
        }
    }
}
