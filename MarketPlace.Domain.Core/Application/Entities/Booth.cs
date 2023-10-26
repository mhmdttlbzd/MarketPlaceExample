using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class Booth
{
    public int SalerId { get; set; }

    public string Name { get; set; } = null!;

    public int? ShopAddressId { get; set; }

    public virtual MainAddress? ShopAddress { get; set; }

    public virtual ICollection<BoothProduct> BoothsProducts { get; set; } = new List<BoothProduct>();

    public virtual Saler Saler { get; set; } = null!;
}
