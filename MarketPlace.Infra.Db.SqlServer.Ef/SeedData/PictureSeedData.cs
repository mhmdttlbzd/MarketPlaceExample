using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
    public class PictureSeedData : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasData(
                new Picture { Id = 1, Path = "product/1.jpg" },
                new Picture { Id = 2, Path = "product/2.jpg" },
                new Picture { Id = 3, Path = "product/3.jpg" },
                new Picture { Id = 4, Path = "product/4.jpg" },
                new Picture { Id = 5, Path = "product/5.jpg" },
                new Picture { Id = 6, Path = "product/6.jpg" },
                new Picture { Id = 7, Path = "product/7.jpg" },
                new Picture { Id = 8, Path = "product/8.jpg" },
                new Picture { Id = 9, Path = "product/9.jpg" }
                );
        }
    }
    public class AuctionPictureSeedData : IEntityTypeConfiguration<AuctionPicture>
    {
        public void Configure(EntityTypeBuilder<AuctionPicture> builder)
        {
            builder.HasData(
                new AuctionPicture { Id = 1, PictureId = 6, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation },
                new AuctionPicture { Id = 2, PictureId = 7, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation },
                new AuctionPicture { Id = 3, PictureId = 8, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation },
                new AuctionPicture { Id = 4, PictureId = 9, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation }
                );
        }
    }
    public class ProductSalerPicSeedData : IEntityTypeConfiguration<ProductSalerPic>
    {
        public void Configure(EntityTypeBuilder<ProductSalerPic> builder)
        {
            builder.HasData(
                new ProductSalerPic { Id = 1, PictureId = 4, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation },
                new ProductSalerPic { Id = 2, PictureId = 5, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation }
                );
        }
    }
    public class ProductCustomerPicSeedData : IEntityTypeConfiguration<ProductCustomerPic>
    {
        public void Configure(EntityTypeBuilder<ProductCustomerPic> builder)
        {
            builder.HasData(
                new ProductCustomerPic { Id = 1, PictureId = 1, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, CustomerId = 2 },
                new ProductCustomerPic { Id = 2, PictureId = 2, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, CustomerId = 2 },
                new ProductCustomerPic { Id = 3, PictureId = 3, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.AwaitConfirmation, CustomerId = 2 }
                );
        }
    }
}
