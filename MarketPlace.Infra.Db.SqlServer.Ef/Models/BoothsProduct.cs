using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class BoothsProduct
{
    public int Id { get; set; }

    public int BoothId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<BoothProductsPrice> BoothProductsPrices { get; set; } = new List<BoothProductsPrice>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<CustomersProductPice> CustomersProductPices { get; set; } = new List<CustomersProductPice>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public virtual Peoduct Product { get; set; } = null!;

    public virtual ICollection<SalersProductPic> SalersProductPics { get; set; } = new List<SalersProductPic>();
}
