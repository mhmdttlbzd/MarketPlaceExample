using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;

        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<int> CreateAsync(ProductInputDto input, CancellationToken cancellationToken)
        {
            return await _productRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _productRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<ProductOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productRepo.GetAllAsync(cancellationToken);
        }

        public async Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _productRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(ProductInputDto input, int id, CancellationToken cancellationToken)
        {
            await _productRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}
