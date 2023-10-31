

using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Domain.Core.Application.Entities._Picture;

public class AuctionPicture : BaseEntity
{
    public int PictureId { get; set; }

    public int AuctionId { get; set; }

    public GeneralStatus Status { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Picture Picture { get; set; } = null!;
}
