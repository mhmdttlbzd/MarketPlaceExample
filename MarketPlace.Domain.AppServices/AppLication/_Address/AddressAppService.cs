using MarketPlace.Domain.Core.Application.Contract.AppServices._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Address
{
    public class AddressAppService : IAddressAppService
    {
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;

        public AddressAppService(ICityService cityService, IProvinceService provinceService)
        {
            _cityService = cityService;
            _provinceService = provinceService;
        }

        public async Task<List<CityDto>> GetCitiesByProvinceId(int id) => await _cityService.GetByProvinceId(id);
        public List<ProvinceDto> GetProvinces() 
            =>  _provinceService.GetAll();

    }
}
