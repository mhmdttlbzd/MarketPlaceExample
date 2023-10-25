using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class BoothProductsPrice
{
    public int Id { get; set; }

    public int BoothProductId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public long Price { get; set; }

    public virtual BoothsProduct BoothProduct { get; set; } = null!;
}
