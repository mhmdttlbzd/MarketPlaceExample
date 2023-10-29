using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute
{
    public interface IProductAttributeRepo: IBaseCrudRepository<ProductsCustomAttribute,
        ProductAttributeOutputDto, ProductAttributeInputDto>
    {

    }
}
