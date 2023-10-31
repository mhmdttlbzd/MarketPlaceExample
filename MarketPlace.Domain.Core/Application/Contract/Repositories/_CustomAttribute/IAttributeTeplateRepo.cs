﻿using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using System.Reflection.Metadata;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute
{
    public interface IAttributeTemplateRepo : IBaseCrudRepository<CustomAttributeTemplate,AttributeTemplateInputDto,AttributeTemplateOutputDto>
    {

    }
}
