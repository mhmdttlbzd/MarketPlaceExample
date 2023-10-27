using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IProductCustomerPicRepo : IBaseCrudRepository<ProductCustomerPic, ProductCustomerPicInputDto, ProductCustomerPicOutputDto>
    {

    }
}
