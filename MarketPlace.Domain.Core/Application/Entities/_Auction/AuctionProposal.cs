using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Customer;

namespace MarketPlace.Domain.Core.Application.Entities._Auction;

public class AuctionProposal : BaseEntity
{
    public int AuctionId { get; set; }

    public long Price { get; set; }

    public int CustomerId { get; set; }

    public virtual Auction Auction { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
