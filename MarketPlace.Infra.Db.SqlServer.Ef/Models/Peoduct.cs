using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Peoduct
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? IsConfirmed { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<BoothProductsAction> BoothProductsActions { get; set; } = new List<BoothProductsAction>();

    public virtual ICollection<BoothsProduct> BoothsProducts { get; set; } = new List<BoothsProduct>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ProductsCustomAttribute> ProductsCustomAttributes { get; set; } = new List<ProductsCustomAttribute>();
}
