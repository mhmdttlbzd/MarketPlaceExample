using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Domain.Core.Application.Entities._Picture;

public class ProductSalerPic : BaseEntity
{
    public int PictureId { get; set; }

    public int BoothProductId { get; set; }

    public GeneralStatus Status { get; set; }

    public virtual BoothProduct BoothProduct { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
