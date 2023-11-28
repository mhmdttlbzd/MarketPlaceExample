using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "SellerProductsVM")]
    public class SellerProductsVM : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public SellerProductsVM(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke(int sellerId)
        {
            var res = _boothProductAppService.GetSellerProducts(sellerId);
            return View(res);
        }
    } 
}
