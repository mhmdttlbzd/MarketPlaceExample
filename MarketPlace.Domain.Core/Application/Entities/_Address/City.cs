using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Entities;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProvinceId { get; set; }

    public virtual ICollection<MainAddress> Addresses { get; set; } = new List<MainAddress>();

    public virtual Province Province { get; set; } = null!;
}
