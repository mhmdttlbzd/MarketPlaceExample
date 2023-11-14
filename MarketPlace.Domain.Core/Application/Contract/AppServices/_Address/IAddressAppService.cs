using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Address
{
    public interface IAddressAppService
    {
        List<ProvinceDto> GetProvinces();
        Task<List<CityDto>> GetCitiesByProvinceId(int id);

        List<CityDto> GetCities();
    }
}
