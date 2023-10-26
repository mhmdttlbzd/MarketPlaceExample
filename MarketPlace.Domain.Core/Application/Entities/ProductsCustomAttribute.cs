using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public class ProductsCustomAttribute
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeValue { get; set; } = null!;

    public virtual CustomAttributeTemplate Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
