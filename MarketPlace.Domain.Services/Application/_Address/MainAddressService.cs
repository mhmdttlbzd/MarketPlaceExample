using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Address
{
    public class MainAddressService : IMainAddressService
    {
        public readonly IMainAddressRepo _mainAddressRepo;

        public MainAddressService(IMainAddressRepo mainAddressRepo)
        {
            _mainAddressRepo = mainAddressRepo;
        }

        public async Task<int> CreateAsync(MainAddressInputDto input, CancellationToken cancellationToken)
        {
            return await _mainAddressRepo.CreateAsync(input,cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _mainAddressRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<MainAddressOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _mainAddressRepo.GetAllAsync(cancellationToken);
        }

        public async Task<MainAddressOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _mainAddressRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(MainAddressInputDto input, int id, CancellationToken cancellationToken)
        {
            await _mainAddressRepo.UpdateAsync(input, id, cancellationToken);
        }
        public async Task<AddressDto> GetAddress(int id, CancellationToken cancellationToken)
            => await _mainAddressRepo.GetAddress(id, cancellationToken);
    }
}
