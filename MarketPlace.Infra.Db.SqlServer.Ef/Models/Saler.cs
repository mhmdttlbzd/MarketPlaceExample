using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Saler
{
    public int Id { get; set; }

    public int SalerTipeId { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual SalerType SalerTipe { get; set; } = null!;
}
