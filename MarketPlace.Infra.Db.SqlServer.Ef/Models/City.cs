using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvienceId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Provience Provience { get; set; } = null!;
}
