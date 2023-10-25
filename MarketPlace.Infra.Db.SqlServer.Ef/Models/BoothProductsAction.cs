using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class BoothProductsAction
{
    public int Id { get; set; }

    public int BootId { get; set; }

    public DateTime ExpiredTime { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<ActionProposal> ActionProposals { get; set; } = new List<ActionProposal>();

    public virtual ICollection<PicturesAction> PicturesActions { get; set; } = new List<PicturesAction>();

    public virtual Peoduct Product { get; set; } = null!;
}
