using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Booth
{
    public class BoothProductsPriceService : IBoothProductsPriceService
    {
        private readonly IBoothProductsPriceRepo _boothProductsPriceRepo;

        public BoothProductsPriceService(IBoothProductsPriceRepo boothProductsPriceRepo)
        {
            _boothProductsPriceRepo = boothProductsPriceRepo;
        }

        public async Task<int> CreateAsync(BoothProductsPriceInputDto input, CancellationToken cancellationToken)
        {
            return await _boothProductsPriceRepo.CreateAsync(input, cancellationToken);
        }
        public async Task UpdateAsync(BoothProductsPriceInputDto input, CancellationToken cancellationToken)
        {
            int lastPriceId = _boothProductsPriceRepo.GetLastPriceIdByProductId(input.BoothProductId);
            await _boothProductsPriceRepo.Teminate(lastPriceId);
            await _boothProductsPriceRepo.CreateAsync(input, cancellationToken);
        }
        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _boothProductsPriceRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<BoothProductsPriceOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _boothProductsPriceRepo.GetAllAsync(cancellationToken);
        }

        public async Task<BoothProductsPriceOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boothProductsPriceRepo.GetByIdAsync(id, cancellationToken);
        }

        public List<ProductPriceDto> GetPricesByProductId(int productId) =>  _boothProductsPriceRepo.GetPricesByProductId(productId);

    }
}
