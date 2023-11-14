

using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Identity.Entities;
using System.Transactions;

namespace MarketPlace.Domain.Core.Application.Entities._Customer;

public partial class Customer: ApplicationUser
{
    public int AddressId { get; set; }
}


public partial class Customer 
{
    public virtual ICollection<AuctionProposal>? AuctionProposals { get; set; } 

    public virtual MainAddress Address { get; set; } = null!;

    public virtual ICollection<Comment>? Comments { get; set; } 

    public virtual ICollection<Order>? Orders { get; set; } 
}
