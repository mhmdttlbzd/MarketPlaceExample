using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;

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
            => await _productRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            => await _productRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<ProductOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _productRepo.GetAllAsync(cancellationToken);

        public async Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _productRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(ProductInputDto input, int id, CancellationToken cancellationToken)
            => await _productRepo.UpdateAsync(input, id, cancellationToken);

        public int GetCount() => _productRepo.GetCount();

        public int AllRequestsCount() => _productRepo.AllRequestsCount();

        public async Task<List<ProductRequestDto>> GetRequests(CancellationToken cancellationToken)
            => await _productRepo.GetRequests(cancellationToken);

        public async Task ConfirmAsync(int id, CancellationToken cancellationToken) => await _productRepo.ConfirmAsync(id, cancellationToken);
        public async Task FaleAsync(int id, CancellationToken cancellationToken) => await _productRepo.FaleAsync(id, cancellationToken);
    }
}
