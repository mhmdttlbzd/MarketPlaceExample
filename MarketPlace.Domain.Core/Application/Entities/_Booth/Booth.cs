using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Identity.Entities;

namespace MarketPlace.Domain.Core.Application.Entities._Booth;

public class Booth : BaseEntity
{
    public string Name { get; set; } = null!;

    public int? ShopAddressId { get; set; }

    public virtual MainAddress? ShopAddress { get; set; }

    public virtual ICollection<BoothProduct> BoothsProducts { get; set; } = new List<BoothProduct>();

    public virtual Saler Saler { get; set; } = null!;
}
