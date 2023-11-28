using MarketPlace.Domain.Core.Application.Contract.AppServices._Seller;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "BoothVM")]
    public class BoothVM : ViewComponent
    {
        private readonly IBoothAppService _boothAppService;

        public BoothVM(IBoothAppService boothAppService)
        {
            _boothAppService = boothAppService;
        }

        public IViewComponentResult Invoke(int categoryId)
        {
            var res = _boothAppService.GetByCategoryId(categoryId);
            return View(res);
        }
    }
}
