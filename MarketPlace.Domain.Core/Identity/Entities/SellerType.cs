using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Identity.Entities;

namespace MarketPlace.Domain.Core.Application.Entities._Saler;

public class SellerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte WagePercent { get; set; }

    public long BaseSalesMoney { get; set; }

    public virtual ICollection<Seller> Salers { get; set; } = new List<Seller>();
}
