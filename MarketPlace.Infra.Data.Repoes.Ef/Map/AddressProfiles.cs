using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class AddressProfiles : Profile
    {
        public AddressProfiles()
        {
            CreateMap<MainAddress, MainAddressOutputDto>();
            CreateMap<MainAddressInputDto, MainAddress>();

            CreateMap<City, CityDto>();
            CreateMap<Province, ProvinceDto>();
        }
    }
}
