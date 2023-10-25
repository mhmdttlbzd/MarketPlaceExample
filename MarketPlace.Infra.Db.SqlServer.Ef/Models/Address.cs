using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Address
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Address1 { get; set; } = null!;

    public int PostalCode { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
