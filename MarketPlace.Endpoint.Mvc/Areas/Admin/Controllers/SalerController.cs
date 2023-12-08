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
        private readonly ISellerAppService _sellerAppService;

        public SalerController( ISellerAppService sellerAppService)
        {
            _sellerAppService = sellerAppService;
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
            await _sellerAppService.Create(input, cancellationToken);
            return LocalRedirect("/Admin");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var res = await _sellerAppService.GetById(id, cancellationToken);
            return View(res);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditPost(GeneralSellerInputDto input, CancellationToken cancellationToken)
        {
            await _sellerAppService.UpdateSeller(input, cancellationToken);
            return LocalRedirect("/Admin");
        }
    }
}
