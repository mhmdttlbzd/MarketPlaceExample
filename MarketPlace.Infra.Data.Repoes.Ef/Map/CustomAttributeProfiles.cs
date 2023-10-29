using AutoMapper;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using System.Reflection.Metadata;

namespace MarketPlace.Infra.Data.Repoes.Ef.Map
{
    public class CustomAttributeProfiles :Profile
    {
        public CustomAttributeProfiles()
        {
            CreateMap<CustomAttributeTemplate, AttributeTemplateDto>();

            CreateMap<ProductsCustomAttribute, ProductAttributeOutputDto>();
            CreateMap<ProductsCustomAttribute, ProductAttributeInputDto>();
        }
    }
}
