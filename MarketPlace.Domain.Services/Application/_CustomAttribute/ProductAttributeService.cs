using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._CustomAttribute
{
    public class ProductAttributeService : IProductAttributeService
    {
        private readonly IProductAttributeRepo _productAttributeRepo;

        public ProductAttributeService(IProductAttributeRepo productAttributeRepo)
        {
            _productAttributeRepo = productAttributeRepo;
        }

        public async Task<int> CreateAsync(ProductAttributeInputDto input, CancellationToken cancellationToken)
        {
            return await _productAttributeRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _productAttributeRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<ProductAttributeOutputDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _productAttributeRepo.GetAllAsync(cancellationToken);
        }

        public async Task<ProductAttributeOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _productAttributeRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(ProductAttributeInputDto input, int id, CancellationToken cancellationToken)
        {
            await _productAttributeRepo.UpdateAsync(input, id, cancellationToken);
        }
    }
}
