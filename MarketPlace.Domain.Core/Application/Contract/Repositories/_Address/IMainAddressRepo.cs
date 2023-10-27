using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Address
{
    public interface IMainAddressRepo : IBaseCrudRepository<MainAddress, MainAddressInputDto,MainAddressOutputDto>
    {
    }
}
