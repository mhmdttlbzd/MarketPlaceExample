using MarketPlace.Domain.Core.Application.Enums;
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

    public record SaleOrderLineDto
    {
        public string CustomerName { get; set; }
        public DateTime dateTime { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string BoothName { get; set; }
    }
    #endregion

    #region OrderLine
    public record OrderLineOutputDto(
        int Id, int OrderId, int BoothProductId, int Quantity, BoothProductOutputDto BoothProduct,
        OrderOutputDto Order
        );
    public record OrderLineInputDto(int OrderId, int BoothProductId, int Quantity);
    #endregion
}
