using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class ActionProposal
{
    public int Id { get; set; }

    public int ActionId { get; set; }

    public long Price { get; set; }

    public int CustomerId { get; set; }

    public virtual BoothProductsAction Action { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
