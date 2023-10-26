using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public OrderStatus Status { get; set; }
}
