using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public GeneralStatus Status { get; set; }


}



public partial class Product
{
    public virtual ICollection<Auction> BoothProductsActions { get; set; } = new List<Auction>();

    public virtual ICollection<BoothProduct> BoothsProducts { get; set; } = new List<BoothProduct>();

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductsCustomAttribute> ProductsCustomAttributes { get; set; } = new List<ProductsCustomAttribute>();

}
