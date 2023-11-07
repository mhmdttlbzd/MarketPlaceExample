using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "ProvinceVM")]
    public class ProvinceViewComponent : ViewComponent
    {
        private readonly IAddressAppService _addressAppService;

        public ProvinceViewComponent(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        public IViewComponentResult Invoke()
        {
            var cities = _addressAppService.GetProvinces();
            return View(cities);
        }
    }
}
