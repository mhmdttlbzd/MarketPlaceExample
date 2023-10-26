using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class AuctionPicture
{
    public int Id { get; set; }

    public int PictureId { get; set; }

    public int AuctionId { get; set; }

    public GeneralStatus Status { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
