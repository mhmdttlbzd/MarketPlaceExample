using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<Product,ProductOutputDto>();
            CreateMap<Product,ProductInputDto>();

            CreateMap<Category, CategoryDto>();
        }
    }
}
