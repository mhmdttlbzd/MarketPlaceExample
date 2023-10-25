using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Booth
{
    public int SalerId { get; set; }

    public string Name { get; set; } = null!;

    public int? ShopAddressId { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<BoothsProduct> BoothsProducts { get; set; } = new List<BoothsProduct>();

    public virtual Saler Saler { get; set; } = null!;
}
