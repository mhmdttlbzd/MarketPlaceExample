using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "TopThreeAuctionsVM")]
    public class TopThreeAuctionsVM : ViewComponent
    {
        private readonly IAuctionAppService _auctionAppService;

        public TopThreeAuctionsVM(IAuctionAppService auctionAppService)
        {
            _auctionAppService = auctionAppService;
        }

        public IViewComponentResult Invoke(int? sellerId = null)
        {
            var res = _auctionAppService.GetThreeBestAuctions(sellerId);
            return View(res);
        }
    }
}
