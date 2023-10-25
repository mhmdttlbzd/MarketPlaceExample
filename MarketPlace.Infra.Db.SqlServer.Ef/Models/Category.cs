using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<CustomAttributeTemlate> CustomAttributeTemlates { get; set; } = new List<CustomAttributeTemlate>();

    public virtual ICollection<Peoduct> Peoducts { get; set; } = new List<Peoduct>();
}
