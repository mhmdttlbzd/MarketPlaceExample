using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Order
{
    public interface IOrderRepo : IBaseCrudRepository<Order, OrderOutputDto, OrderInputDto>
    {
    }
}
