using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Entities;

public class SalerType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public byte TaskPercent { get; set; }

    public virtual ICollection<Saler> Salers { get; set; } = new List<Saler>();
}
