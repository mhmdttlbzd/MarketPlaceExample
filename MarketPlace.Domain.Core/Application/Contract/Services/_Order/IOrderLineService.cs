using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Order
{
    public interface IOrderLineService
    {
        Task<int> CreateAsync(OrderLineInputDto input, CancellationToken cancellationToken);
        Task<List<OrderLineOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<OrderLineOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(OrderLineInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
