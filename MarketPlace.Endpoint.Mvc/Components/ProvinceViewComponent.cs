using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Endpoint.Mvc.Models.Address;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Components
{
    [ViewComponent(Name = "AddressVM")]
    public class ProvinceViewComponent : ViewComponent
    {
        private readonly IAddressAppService _addressAppService;

        public ProvinceViewComponent(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        public IViewComponentResult Invoke(MainAddressOutputDto address)
        {
            var provinces = _addressAppService.GetProvinces();
            var cities =  _addressAppService.GetCities();
            var res = new GeneralAddressViewModel
            {
                Provinces = provinces,
                Cities = cities,
                Address = address
            };
            return View(res);
        }
    }
}
