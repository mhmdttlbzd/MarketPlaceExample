using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Temlate
    public record AttributeTemlateDto(
        int Id, int CategoryId, string Title, CategoryDto Category, 
        ICollection<ProductAttributeInputDto> ProductsCustomAttributes
        );
    #endregion


    #region Product
    public record ProductAttributeOutputDto(
        int Id, int ProductId, int AttributeId, string AttributeValue, AttributeTemlateDto Attribute,
        ProductOutputDto Product
        );
    public record ProductAttributeInputDto(
    int ProductId, int AttributeId, string AttributeValue
    );
    #endregion
}
