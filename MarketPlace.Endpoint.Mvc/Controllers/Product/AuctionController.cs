using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Product
{
    public class AuctionController : Controller
    {
        private readonly IAuctionAppService _auctionAppService;

        public AuctionController(IAuctionAppService auctionAppService)
        {
            _auctionAppService = auctionAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id,CancellationToken cancellationToken)
        {
            var res =await _auctionAppService.GetById(id, cancellationToken);
            return View(res);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateProposal(int id, long price, CancellationToken cancellationToken)
        {
            await _auctionAppService.CreateProposal(User.Identity.Name, id, price, cancellationToken);
            return LocalRedirect("~/Home");
        }
    }
}
