using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

public class CustomAttributeTemplate
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Title { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductsCustomAttribute> ProductsCustomAttributes { get; set; } = new List<ProductsCustomAttribute>();
}
