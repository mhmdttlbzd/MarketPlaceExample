using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Address
{
    public interface IMainAddressRepo : IBaseCrudRepository<MainAddress, MainAddressInputDto,MainAddressOutputDto>
    {
        Task<AddressDto> GetAddress(int id, CancellationToken cancellationToken);
    }
}
