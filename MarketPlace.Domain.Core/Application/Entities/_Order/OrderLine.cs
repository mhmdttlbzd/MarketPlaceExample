using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Entities;

public class OrderLine : BaseEntity
{
    public int OrderId { get; set; }

    public int BoothProductId { get; set; }

    public int Quantity { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
