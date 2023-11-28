using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Address
{
    public interface IMainAddressService
    {
        Task<int> CreateAsync(MainAddressInputDto input, CancellationToken cancellationToken);
        Task<List<MainAddressOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<MainAddressOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(MainAddressInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<AddressDto> GetAddress(int id, CancellationToken cancellationToken);
    }
}
