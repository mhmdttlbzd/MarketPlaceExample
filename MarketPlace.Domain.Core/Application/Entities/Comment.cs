﻿using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public byte Satisfaction { get; set; }

    public string Description { get; set; } = null!;

    public GeneralStatus Status { get; set; }

}


public partial class Comment
{
    public int BoothProductId { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
