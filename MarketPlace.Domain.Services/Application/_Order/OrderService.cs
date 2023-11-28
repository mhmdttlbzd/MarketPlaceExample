using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<int> CreateAsync(OrderInputDto input, CancellationToken cancellationToken)
            => await _orderRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _orderRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<OrderOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _orderRepo.GetAllAsync(cancellationToken);

        public async Task<OrderOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _orderRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(OrderInputDto input, int id, CancellationToken cancellationToken)
            =>await _orderRepo.UpdateAsync(input, id, cancellationToken);

        public async Task<int> GetSaledProductCount(CancellationToken cancellationToken) 
            =>await _orderRepo.GetSaledProductCount(cancellationToken);

        public async Task<int> GetActiveOrderId(int customerId,CancellationToken cancellationToken)
        {
            var id =await _orderRepo.GetActiveOrderId(customerId);
            if (id == null)
            {
                id =await _orderRepo.CreateAsync(new OrderInputDto(customerId), cancellationToken);
            }
            return (int)id;
        }

        public async Task<OrderDto> GetActiveOrder(int customerId)
            => await _orderRepo.GetActiveOrder(customerId);

        public async Task BuyOrder(int orderId) =>await _orderRepo.BuyOrder(orderId);
    }
}
