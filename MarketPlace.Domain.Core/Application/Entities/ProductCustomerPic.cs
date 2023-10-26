using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class ProductCustomerPic
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public int BoothProductId { get; set; }

    public int CustomerId { get; set; }

    public GeneralStatus Status { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
