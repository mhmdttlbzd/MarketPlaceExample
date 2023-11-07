using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoint.Mvc.Controllers.Address
{
    public class AddressController : Controller
    {
        private readonly IAddressAppService _addressAppService;

        public AddressController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCitiesByProvinceId(int id)
        {
            var res =await _addressAppService.GetCitiesByProvinceId(id);
            return Ok(res);
        }
    }
}
