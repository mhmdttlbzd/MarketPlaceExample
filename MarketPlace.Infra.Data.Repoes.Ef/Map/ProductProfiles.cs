using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
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
            CreateMap<ProductInputDto, Product>();

            CreateMap<Category, CategoryDto>();
        }
    }
}
