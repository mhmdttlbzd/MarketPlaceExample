

using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Identity.Entities;

namespace MarketPlace.Domain.Core.Application.Entities._Saler;

public class Seller  : ApplicationUser
{
    public int SellerTypeId { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual SellerType SellerType { get; set; } = null!;
}
