using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "ProductsVM")]
    public class ProductsVM : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public ProductsVM(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke(int categoryId)
        {
            var res = _boothProductAppService.GetByCategoryId(categoryId);
            return View(res);
        }
    } 
}
