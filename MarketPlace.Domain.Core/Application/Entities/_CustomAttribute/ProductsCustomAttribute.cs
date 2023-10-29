using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;

namespace MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

public class ProductsCustomAttribute : BaseEntity
{
    public int ProductId { get; set; }

    public int AttributeId { get; set; }

    public string AttributeValue { get; set; } = null!;

    public virtual CustomAttributeTemplate Attribute { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
