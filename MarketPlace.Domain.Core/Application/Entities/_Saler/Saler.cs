

using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Domain.Core.Application.Entities._Saler;

public class Saler 
{
    public int Id { get; set; }
    public int SalerTypeId { get; set; }

    public virtual Booth? Booth { get; set; }

    public virtual SalerType SalerType { get; set; } = null!;
}
