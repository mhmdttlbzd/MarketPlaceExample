using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._Address;

public class MainAddress : BaseEntity
{
    public int CityId { get; set; }

    public string Address { get; set; } = null!;

    public int PostalCode { get; set; }

    public virtual Booth Booth { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Customer Customer { get; set; } 
}
