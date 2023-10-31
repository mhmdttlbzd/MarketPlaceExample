using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Temlate
    public record AttributeTemplateOutputDto(
        int Id,  string Title, 
        ICollection<ProductAttributeInputDto> ProductsCustomAttributes
        );
    public record AttributeTemplateInputDto(
         int CategoryId, string Title);
    #endregion


    #region Product
    public record ProductAttributeOutputDto(
        int Id, int ProductId, int AttributeId, string AttributeValue, AttributeTemplateOutputDto Attribute,
        ProductOutputDto Product
        );
    public record ProductAttributeInputDto(
    int ProductId, int AttributeId, string AttributeValue
    );
    #endregion
}
