using System;
using System.Collections.Generic;

namespace MarketPlace.Domain.Core.Application.Entities._Picture;

public class Picture
{
    public int Id { get; set; }

    public string Path { get; set; } = null!;

    public string? Alt { get; set; }

    public virtual ICollection<ProductCustomerPic> CustomersProductPices { get; set; } = new List<ProductCustomerPic>();

    public virtual ICollection<AuctionPicture> PicturesActions { get; set; } = new List<AuctionPicture>();

    public virtual ICollection<ProductSalerPic> SalersProductPics { get; set; } = new List<ProductSalerPic>();
}
