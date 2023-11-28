using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "TowNewAuctionVM")]
    public class TowNewAuctionVM : ViewComponent
    {
        private readonly IAuctionAppService _auctionAppService;

        public TowNewAuctionVM(IAuctionAppService auctionAppService)
        {
            _auctionAppService = auctionAppService;
        }
        public IViewComponentResult Invoke()
        {
            var res = _auctionAppService.GetTowNewAuctions();
            return View(res);
        }
    }
}
