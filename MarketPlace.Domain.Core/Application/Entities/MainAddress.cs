using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class MainAddress
{
    public int Id { get; set; }

    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public int PostalCode { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
