using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
