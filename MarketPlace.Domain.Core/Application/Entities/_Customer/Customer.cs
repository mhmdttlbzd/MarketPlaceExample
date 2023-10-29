

using MarketPlace.Domain.Core.Application.Entities._Address;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Order;

namespace MarketPlace.Domain.Core.Application.Entities._Customer;

public partial class Customer 
{
    public int Id { get; set; }
    public int AddressId { get; set; }

}


public partial class Customer 
{
    public virtual ICollection<AuctionProposal> ActionProposals { get; set; } = new List<AuctionProposal>();


    public virtual MainAddress Address { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
