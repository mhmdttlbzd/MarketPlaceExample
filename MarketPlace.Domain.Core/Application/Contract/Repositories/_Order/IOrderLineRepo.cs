using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Order
{
    public interface IOrderLineRepo : IBaseCrudRepository<OrderLine, OrderLineInputDto, OrderLineOutputDto>
    {
    }
}
