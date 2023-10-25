using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Comment
{
    public int Id { get; set; }

    public byte SatisFaction { get; set; }

    public string Description { get; set; } = null!;

    public int BoothProductId { get; set; }

    public bool? IsConfirmed { get; set; }

    public int? CustomerId { get; set; }

    public virtual BoothsProduct BoothProduct { get; set; } = null!;

    public virtual Customer? Customer { get; set; }
}
