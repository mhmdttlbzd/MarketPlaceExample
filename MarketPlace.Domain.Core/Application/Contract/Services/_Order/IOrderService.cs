using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Order
{
    public interface IOrderService
    {
        Task<int> CreateAsync(OrderInputDto input, CancellationToken cancellationToken);
        Task<List<OrderOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<OrderOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(OrderInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<int> GetSaledProductCount(CancellationToken cancellationToken);
        Task<int> GetActiveOrderId(int customerId, CancellationToken cancellationToken);
        Task<OrderDto> GetActiveOrder(int customerId);
        Task BuyOrder(int orderId);
    }
}
