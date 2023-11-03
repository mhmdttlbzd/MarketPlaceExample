using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._Address;

public class MainAddress : BaseEntity
{
    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public uint PostalCode { get; set; }

    public virtual ICollection<Booth> Booths { get; set; } = new List<Booth>();

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
