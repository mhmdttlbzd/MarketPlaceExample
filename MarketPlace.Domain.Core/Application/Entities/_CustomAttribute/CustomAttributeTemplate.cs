using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

public class CustomAttributeTemplate
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<CategoryCustomAttribute>? CategoryCustomAttributes { get; set; } = new List<CategoryCustomAttribute>();

    public virtual ICollection<ProductsCustomAttribute>? ProductsCustomAttributes { get; set; } = new List<ProductsCustomAttribute>();
}
