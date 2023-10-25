using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Picture
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public string? Alt { get; set; }

    public virtual ICollection<CustomersProductPice> CustomersProductPices { get; set; } = new List<CustomersProductPice>();

    public virtual ICollection<PicturesAction> PicturesActions { get; set; } = new List<PicturesAction>();

    public virtual ICollection<SalersProductPic> SalersProductPics { get; set; } = new List<SalersProductPic>();
}
