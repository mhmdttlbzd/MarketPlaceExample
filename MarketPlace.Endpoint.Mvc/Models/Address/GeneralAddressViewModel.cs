using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Endpoint.Mvc.Models.Address
{
    public class GeneralAddressViewModel
    {

        public List<CityDto> Cities { get; set; }
        public List<ProvinceDto> Provinces { get; set; }

        public MainAddressOutputDto? Address { get; set; }
    }
}
