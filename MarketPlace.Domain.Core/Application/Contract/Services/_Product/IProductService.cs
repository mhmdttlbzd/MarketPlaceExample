using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Product
{
    public interface IProductService
    {
        Task<int> CreateAsync(ProductInputDto input, CancellationToken cancellationToken);
        Task<List<ProductOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(ProductInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int GetCount();
        int AllRequestsCount();
        Task<List<ProductRequestDto>> GetRequests(CancellationToken cancellationToken);
        Task FaleAsync(int id, CancellationToken cancellationToken);
        Task ConfirmAsync(int id, CancellationToken cancellationToken);
    }
}
