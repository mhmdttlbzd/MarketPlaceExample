using System;
using System.Collections.Generic;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;

namespace MarketPlace.Domain.Core.Application.Entities._Booth;

public partial class BoothProduct : BaseEntity
{
    public int Quantity { get; set; }
    public int BoothId { get; set; }
    public int ProductId { get; set; }

}


public partial class BoothProduct
{

    public virtual Booth Booth { get; set; } = null!;

    public virtual ICollection<BoothProductsPrice> BoothProductsPrices { get; set; } = new List<BoothProductsPrice>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<ProductCustomerPic> CustomersProductPices { get; set; } = new List<ProductCustomerPic>();

    public virtual ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();


    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductSalerPic> SalersProductPics { get; set; } = new List<ProductSalerPic>();

}
