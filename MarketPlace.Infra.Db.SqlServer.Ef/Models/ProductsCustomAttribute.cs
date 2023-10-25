using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class ProductsCustomAttribute
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeValue { get; set; } = null!;

    public virtual CustomAttributeTemlate Attribute { get; set; } = null!;

    public virtual Peoduct Product { get; set; } = null!;
}
