using MarketPlace.Domain.Core.Application.Contract.Repositories._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Picture
{
    public class ProductSalerPicService : IProductSalerPicService
    {
        private readonly IProductSalerPicRepo _productSalerPicRepo;

        public ProductSalerPicService(IProductSalerPicRepo productSalerPicRepo)
        {
            _productSalerPicRepo = productSalerPicRepo;
        }

        public async Task<int> CreateAsync(ProductSalerPicInputDto input, CancellationToken cancellationToken)
            => await _productSalerPicRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _productSalerPicRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<ProductSalerPicOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _productSalerPicRepo.GetAllAsync(cancellationToken);

        public async Task<ProductSalerPicOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _productSalerPicRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(ProductSalerPicInputDto input, int id, CancellationToken cancellationToken)
            =>await _productSalerPicRepo.UpdateAsync(input, id, cancellationToken);

		public int GetRequestsCount() => _productSalerPicRepo.GetRequestsCount();

	}

}
