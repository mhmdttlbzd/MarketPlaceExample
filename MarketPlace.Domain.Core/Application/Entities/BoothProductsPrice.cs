using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class BoothProductsPrice
{
    public int Id { get; set; }

    public int BoothProductId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public long Price { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;
}
