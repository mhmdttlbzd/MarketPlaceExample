using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public partial class Customer
{
    public int Id { get; set; }

}


public partial class Customer
{
    public virtual ICollection<AuctionProposal> ActionProposals { get; set; } = new List<AuctionProposal>();

    public int AddressId { get; set; }

    public virtual MainAddress Address { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
