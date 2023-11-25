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
                new Picture { Id = 9, Path = "product/9.jpg" },
                new Picture { Id = 10, Path = "product/Auction_american_1.jpeg" },
                new Picture { Id = 11, Path = "product/Auction_american_2.jpeg" },
                new Picture { Id = 12, Path = "product/Auction_monster_1.jpeg" },
                new Picture { Id = 13, Path = "product/Auction_monster_2.jpeg" },
                new Picture { Id = 14, Path = "product/Auction_police_1.jpeg" },
                new Picture { Id = 15, Path = "product/Auction_police_2.jpeg" },
                new Picture { Id = 16, Path = "product/Auction_pilot_1.jpeg" },
                new Picture { Id = 17, Path = "product/Auction_randolph_1.jpeg" },
                new Picture { Id = 18, Path = "product/Auction_randolph_2.jpeg" },
                new Picture { Id = 19, Path = "product/Sbooth_american_1.jpeg" },
                new Picture { Id = 20, Path = "product/Sbooth_american_2.jpeg" },
                new Picture { Id = 21, Path = "product/Sbooth_monster_1.jpeg" },
                new Picture { Id = 22, Path = "product/Sbooth_monster_2.jpeg" },
                new Picture { Id = 23, Path = "product/Sbooth_police_1.jpeg" },
                new Picture { Id = 24, Path = "product/Sbooth_police_2.jpeg" },
                new Picture { Id = 25, Path = "product/Sbooth_pilot_1.jpeg" },
                new Picture { Id = 26, Path = "product/Sbooth_vest_1.jpeg" },
                new Picture { Id = 27, Path = "product/Sbooth_vest_2.jpeg" },
                new Picture { Id = 28, Path = "product/Sbooth_vest_3.jpeg" },
                new Picture { Id = 29, Path = "product/Sbooth_vest_4.jpeg" },
                new Picture { Id = 30, Path = "product/Sbooth_suit_1.jpeg" },
                new Picture { Id = 31, Path = "product/Sbooth_suit_2.jpeg" },
                new Picture { Id = 32, Path = "product/Sbooth_suit_3.jpeg" },
                new Picture { Id = 33, Path = "product/Sbooth_suit_4.jpeg" },
                new Picture { Id = 34, Path = "product/Sbooth_bengalShirt_1.jpeg" },
                new Picture { Id = 35, Path = "product/Sbooth_bengalShirt_2.jpeg" },
                new Picture { Id = 36, Path = "product/Sbooth_bengalShirt_3.jpeg" },
                new Picture { Id = 37, Path = "product/Sbooth_bengalShirt_4.jpeg" },
                new Picture { Id = 38, Path = "product/Sbooth_arka_1.jpg" },
                new Picture { Id = 39, Path = "product/Sbooth_arka_2.webp" },
                new Picture { Id = 40, Path = "product/Sbooth_arka_3.webp" },
                new Picture { Id = 41, Path = "product/Sbooth_kiubi_1.webp" },
                new Picture { Id = 42, Path = "product/Sbooth_kiubi_2.webp" },
                new Picture { Id = 43, Path = "product/Sbooth_kiubi_3.webp" },
                new Picture { Id = 44, Path = "product/Sbooth_kiubi_4.webp" },
                new Picture { Id = 45, Path = "product/Sbooth_kiubi_5.webp" },
                new Picture { Id = 46, Path = "product/Sbooth_kiubi_6.webp" },
                new Picture { Id = 47, Path = "product/Sbooth_kiubi_7.webp" },
                new Picture { Id = 48, Path = "product/Sbooth_coffeepot_1.webp" },
                new Picture { Id = 49, Path = "product/Sbooth_coffeepot_2.webp" },
                new Picture { Id = 50, Path = "product/Sbooth_coffeepot_3.jpg" },
                new Picture { Id = 51, Path = "product/Sbooth_pot_1.webp" },
                new Picture { Id = 52, Path = "product/Sbooth_pot_2.webp" },
                new Picture { Id = 53, Path = "product/Sbooth_pot_3.webp" },
                new Picture { Id = 54, Path = "product/Sbooth_pot_4.webp" },
                new Picture { Id = 55, Path = "product/Sbooth_pot_5.webp" },
                new Picture { Id = 56, Path = "product/Sbooth_shirt_1.webp" },
                new Picture { Id = 57, Path = "product/Sbooth_shirt_2.webp" },
                new Picture { Id = 58, Path = "product/Sbooth_shirt_3.webp" },
                new Picture { Id = 59, Path = "product/Sbooth_shirt_4.webp" },
                new Picture { Id = 60, Path = "product/Sbooth_shirt_5.webp" },
                new Picture { Id = 61, Path = "product/Sbooth_shirt_6.webp" }

                );
        }
    }
    public class AuctionPictureSeedData : IEntityTypeConfiguration<AuctionPicture>
    {
        public void Configure(EntityTypeBuilder<AuctionPicture> builder)
        {
            builder.HasData(
                new AuctionPicture { Id = 1, PictureId = 6, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 2, PictureId = 7, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 3, PictureId = 8, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 4, PictureId = 9, AuctionId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 5, PictureId = 10, AuctionId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 6, PictureId = 11, AuctionId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 7, PictureId = 12, AuctionId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 8, PictureId = 13, AuctionId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 9, PictureId = 14, AuctionId = 5, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 10, PictureId = 15, AuctionId = 5, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 11, PictureId = 16, AuctionId = 6, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 12, PictureId = 17, AuctionId = 7, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new AuctionPicture { Id = 13, PictureId = 18, AuctionId = 7, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed }
                );
        }
    }
    public class ProductSalerPicSeedData : IEntityTypeConfiguration<ProductSalerPic>
    {
        public void Configure(EntityTypeBuilder<ProductSalerPic> builder)
        {
            builder.HasData(
                new ProductSalerPic { Id = 1, PictureId = 4, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 2, PictureId = 5, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 3, PictureId = 19, BoothProductId = 5, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 4, PictureId = 20, BoothProductId = 5, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 5, PictureId = 21, BoothProductId = 6, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 6, PictureId = 22, BoothProductId = 6, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 7, PictureId = 23, BoothProductId = 7, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 8, PictureId = 24, BoothProductId = 7, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 9, PictureId = 25, BoothProductId = 8, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 10, PictureId = 26, BoothProductId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 11, PictureId = 27, BoothProductId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 12, PictureId = 28, BoothProductId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 13, PictureId = 29, BoothProductId = 3, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 14, PictureId = 30, BoothProductId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 15, PictureId = 31, BoothProductId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 16, PictureId = 32, BoothProductId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 17, PictureId = 33, BoothProductId = 4, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 18, PictureId = 34, BoothProductId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 19, PictureId = 35, BoothProductId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 20, PictureId = 36, BoothProductId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 21, PictureId = 37, BoothProductId = 1, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 22, PictureId = 38, BoothProductId = 11, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 23, PictureId = 39, BoothProductId = 11, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 24, PictureId = 40, BoothProductId = 11, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 25, PictureId = 41, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 26, PictureId = 42, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 27, PictureId = 43, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 28, PictureId = 44, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 29, PictureId = 45, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 30, PictureId = 46, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 31, PictureId = 47, BoothProductId = 12, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 32, PictureId = 48, BoothProductId = 14, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 33, PictureId = 49, BoothProductId = 14, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 34, PictureId = 50, BoothProductId = 14, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 35, PictureId = 51, BoothProductId = 10, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 36, PictureId = 52, BoothProductId = 10, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 37, PictureId = 53, BoothProductId = 10, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 38, PictureId = 54, BoothProductId = 10, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 39, PictureId = 55, BoothProductId = 10, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 40, PictureId = 56, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 41, PictureId = 57, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 42, PictureId = 58, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 43, PictureId = 59, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 44, PictureId = 60, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed },
                new ProductSalerPic { Id = 45, PictureId = 61, BoothProductId = 2, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed }
                );
        }
    }
    public class ProductCustomerPicSeedData : IEntityTypeConfiguration<ProductCustomerPic>
    {
        public void Configure(EntityTypeBuilder<ProductCustomerPic> builder)
        {
            builder.HasData(
                new ProductCustomerPic { Id = 1, PictureId = 1, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, CustomerId = 2 },
                new ProductCustomerPic { Id = 2, PictureId = 2, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, CustomerId = 2 },
                new ProductCustomerPic { Id = 3, PictureId = 3, BoothProductId = 15, CreatedAt = DateTime.Now, Status = GeneralStatus.Confirmed, CustomerId = 2 }
                );
        }
    }
}
