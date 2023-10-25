﻿using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class OrderLine
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int BoothProductId { get; set; }

    public int Quantity { get; set; }

    public virtual BoothsProduct BoothProduct { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
