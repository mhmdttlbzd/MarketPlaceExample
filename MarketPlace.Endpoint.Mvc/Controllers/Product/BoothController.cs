using MarketPlace.Domain.Core.Identity.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class BoothController : Controller
    {
        private readonly ISellerAppService _sellerAppService;

        public BoothController(ISellerAppService sellerAppService)
        {
            _sellerAppService = sellerAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var res = await _sellerAppService.GetGeneral(id);
            return View(res);
        }
    }
}
