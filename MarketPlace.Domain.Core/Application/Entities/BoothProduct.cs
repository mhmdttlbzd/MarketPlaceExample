using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities;

public partial class BoothProduct
{
    public int Id { get; set; }

    public int Quantity { get; set; }

}


public partial class BoothProduct
{
    public int BoothId { get; set; }

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<BoothProductsPrice> BoothProductsPrices { get; set; } = new List<BoothProductsPrice>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ProductCustomerPic> CustomersProductPices { get; set; } = new List<ProductCustomerPic>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductSalerPic> SalersProductPics { get; set; } = new List<ProductSalerPic>();

}
