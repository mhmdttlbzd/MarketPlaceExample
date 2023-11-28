using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "BestProductsVM")]
    public class BestProductsVM : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public BestProductsVM(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke()
        {
            var res = _boothProductAppService.GetBestProducts(8);
            return View(res);
        }
    } 
}
