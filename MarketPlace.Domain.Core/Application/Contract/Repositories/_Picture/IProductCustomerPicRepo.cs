using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IProductCustomerPicRepo : IBaseCrudRepository<ProductCustomerPic, ProductCustomerPicInputDto, ProductCustomerPicOutputDto>
    {

    }
}
