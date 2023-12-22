using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Booth
{
    public class BoothProductService : IBoothProductService
    {
        private readonly IBoothProductRepo _boothProductRepo;

        public BoothProductService(IBoothProductRepo boothProductRepo)
        {
            _boothProductRepo = boothProductRepo;
        }
        public int GetCount() => _boothProductRepo.GetCount();
        public async Task<int> CreateAsync(BoothProductInputDto input, CancellationToken cancellationToken)
        {
            return await _boothProductRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _boothProductRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<BoothProductOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _boothProductRepo.GetAllAsync(cancellationToken);
        }

        public async Task<BoothProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _boothProductRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(BoothProductInputDto input, int id, CancellationToken cancellationToken)
        {
            await _boothProductRepo.UpdateAsync(input, id, cancellationToken);
        }

        public List<GeneralBoothProductDto> GetBestProducts(int Count) => _boothProductRepo.GetBestProducts(Count);

        public List<GeneralBoothProductDto> GetByCategoryId(int id) => _boothProductRepo.GetByCategoryId(id);
        public List<GeneralBoothProductDto> GetSellerProducts(int sellerId) => _boothProductRepo.GetSellerProducts(sellerId);
    }
}
