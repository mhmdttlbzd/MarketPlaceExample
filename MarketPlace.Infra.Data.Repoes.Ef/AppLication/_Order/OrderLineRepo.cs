using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef.Models;

namespace MarketPlace.Infra.Data.Repoes.Ef.AppLication._Order
{
    public class OrderLineRepo : BaseEntityCrudRepository<OrderLine,
OrderLineInputDto, OrderLineOutputDto>, IOrderLineRepo
    {
        public OrderLineRepo(MarketPlaceDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
