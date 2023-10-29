﻿

using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

namespace MarketPlace.Domain.Core.Application.Entities._Prodoct;

public partial class Product : BaseEntity
{

    public string Name { get; set; } = null!;

    public GeneralStatus Status { get; set; }

    public int CategoryId { get; set; }

}



public partial class Product
{
    public virtual ICollection<Auction> BoothProductsActions { get; set; } = new List<Auction>();

    public virtual ICollection<BoothProduct> BoothsProducts { get; set; } = new List<BoothProduct>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductsCustomAttribute> ProductsCustomAttributes { get; set; } = new List<ProductsCustomAttribute>();

}
