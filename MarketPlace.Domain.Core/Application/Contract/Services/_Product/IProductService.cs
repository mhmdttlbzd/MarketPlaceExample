using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Product
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductInputDto input, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(ProductInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
