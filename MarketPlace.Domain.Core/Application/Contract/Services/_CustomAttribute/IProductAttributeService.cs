using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute
{
    public interface IProductAttributeService
    {
        Task<int> CreateAsync(ProductAttributeInputDto input, CancellationToken cancellationToken);
        Task<List<ProductAttributeOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductAttributeOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(ProductAttributeInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
