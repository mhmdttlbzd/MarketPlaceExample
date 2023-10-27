using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Entities;

public class AuctionProposal : BaseEntity
{
    public int AuctionId { get; set; }

    public long Price { get; set; }

    public int CustomerId { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
