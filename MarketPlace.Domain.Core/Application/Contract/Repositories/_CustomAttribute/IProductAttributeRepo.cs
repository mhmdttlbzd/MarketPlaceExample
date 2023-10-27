using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute
{
    public interface IProductAttributeRepo: IBaseCrudRepository<ProductsCustomAttribute,
        ProductAttributeOutputDto, ProductAttributeInputDto>
    {

    }
}
