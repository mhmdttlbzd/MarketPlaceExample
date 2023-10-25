using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class SalerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte TaskPercent { get; set; }

    public virtual ICollection<Saler> Salers { get; set; } = new List<Saler>();
}
