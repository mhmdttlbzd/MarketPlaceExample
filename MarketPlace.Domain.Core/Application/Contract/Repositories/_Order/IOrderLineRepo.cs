using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Order;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Order
{
    public interface IOrderLineRepo : IBaseCrudRepository<OrderLine, OrderLineInputDto, OrderLineOutputDto>
    {
        Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken);
    }
}
