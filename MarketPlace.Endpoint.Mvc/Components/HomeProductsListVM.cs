using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "HomeProductsListVM")]
    public class HomeProductsListVM : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public HomeProductsListVM(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke()
        {
            var res = _boothProductAppService.GetBestProducts(15).Skip(6).OrderBy(b => b.ProductName).ToList();
            return View(res);
        }
    }
}
