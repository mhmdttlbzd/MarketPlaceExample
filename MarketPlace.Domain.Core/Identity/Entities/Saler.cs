

using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Identity.Entities;

namespace MarketPlace.Domain.Core.Application.Entities._Saler;

public class Saler  : ApplicationUser
{
    public int SalerTypeId { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual SalerType SalerType { get; set; } = null!;
}
