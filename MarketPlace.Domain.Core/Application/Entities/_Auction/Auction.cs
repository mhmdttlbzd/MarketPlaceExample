using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._Auction;

public class Auction : BaseEntity
{
    public int BootId { get; set; }

    public DateTime ExpiredTime { get; set; }

    public long BasePrice { get; set; } 

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<AuctionProposal> AuctionProposals { get; set; } = new List<AuctionProposal>();

    public virtual ICollection<AuctionPicture> PicturesActions { get; set; } = new List<AuctionPicture>();

    public virtual Product Product { get; set; } = null!;
}
