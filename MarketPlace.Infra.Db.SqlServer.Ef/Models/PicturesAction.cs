using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class PicturesAction
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public int ActionId { get; set; }

    public bool IsConfirmed { get; set; }

    public virtual BoothProductsAction Action { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
