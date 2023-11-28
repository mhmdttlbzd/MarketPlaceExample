using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "DownThreeProductVM")]
    public class DownThreeProductVM : ViewComponent
    {
        private readonly IBoothProductAppService _boothProductAppService;

        public DownThreeProductVM(IBoothProductAppService boothProductAppService)
        {
            _boothProductAppService = boothProductAppService;
        }

        public IViewComponentResult Invoke()
        {
            var res = _boothProductAppService.GetBestProducts(6).OrderBy(b => b.ProductName).Skip(3).ToList();
            return View(res);
        }
    }
}
