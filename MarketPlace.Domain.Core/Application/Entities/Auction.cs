using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class Auction
{
    public int Id { get; set; }

    public int BootId { get; set; }

    public DateTime ExpiredTime { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<AuctionProposal> AuctionProposals { get; set; } = new List<AuctionProposal>();

    public virtual ICollection<AuctionPicture> PicturesActions { get; set; } = new List<AuctionPicture>();

    public virtual Product Product { get; set; } = null!;
}
