using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._Order;

public class Order 
{
    public int Id { get;set; }

    public int CustomerId { get; set; }

    public DateTime BuyedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public ICollection<OrderLine> OrderLines { get; set; }

    public OrderStatus Status { get; set; }
}
