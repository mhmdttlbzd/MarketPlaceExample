using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Order
{
    public class OrderLineService : IOrderLineService
    {
        private readonly IOrderLineRepo _orderLineRepo;

        public OrderLineService(IOrderLineRepo orderLineRepo)
        {
            _orderLineRepo = orderLineRepo;
        }

        public async Task<int> CreateAsync(OrderLineInputDto input, CancellationToken cancellationToken)
            => await _orderLineRepo.CreateAsync(input, cancellationToken);

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
            =>await _orderLineRepo.DeleteAsync(id, cancellationToken);

        public async Task<List<OrderLineOutputDto>> GetAllAsync(CancellationToken cancellationToken)
            => await _orderLineRepo.GetAllAsync(cancellationToken);

        public async Task<OrderLineOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _orderLineRepo.GetByIdAsync(id, cancellationToken);

        public async Task UpdateAsync(OrderLineInputDto input, int id, CancellationToken cancellationToken)
            =>await _orderLineRepo.UpdateAsync(input, id, cancellationToken);
        public async Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken)
            => await _orderLineRepo.GetSaledProducts(cancellationToken);
    }
}
