using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class ProductSalerPic
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public int BoothProductId { get; set; }

    public GeneralStatus Status { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
