using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Order
    public record OrderOutputDto(
         int Id, int CustomerId, CustomerOutputDto Customer, ICollection<OrderLineOutputDto> OrderLines, OrderStatus Status
        );
    public record OrderInputDto(int CustomerId, OrderStatus Status = OrderStatus.Active);
    #endregion

    #region OrderLine
    public record OrderLineOutputDto(
        int Id, int OrderId, int BoothProductId, int Quantity, BoothProductOutputDto BoothProduct,
        OrderOutputDto Order
        );
    public record OrderLineInputDto(int OrderId, int BoothProductId, int Quantity);
    #endregion
}
