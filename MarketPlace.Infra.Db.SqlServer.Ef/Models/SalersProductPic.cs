using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class SalersProductPic
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public int BoothProductId { get; set; }

    public bool? IsConfirmed { get; set; }

    public virtual BoothsProduct BoothProduct { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
