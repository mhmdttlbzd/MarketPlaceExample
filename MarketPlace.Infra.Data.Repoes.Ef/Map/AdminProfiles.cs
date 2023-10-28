using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Admin;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class AdminProfiles : Profile
    {
        public AdminProfiles()
        {
            CreateMap<Admin,AdminInputDto>();
            CreateMap<Admin,AdminOutputDto>();
        }
    }
}
