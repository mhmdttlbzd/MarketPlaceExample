using MarketPlace.Domain.Core.Application.Entities._Booth;
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
    public class BoothSeedData : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> builder)
        {
            builder.HasData(
                new Booth { Id = 4, Name = "رضا لباس", CreatedAt = DateTime.Now, ShopAddressId = 3,SalesMoney = 2700000 },
                new Booth { Id = 5, Name = "برادران افشار", CreatedAt = DateTime.Now, ShopAddressId = 4 , SalesMoney = 1600000 }
                );
        }
    }
    public class BoothProductSeedData : IEntityTypeConfiguration<BoothProduct>
    {
        public void Configure(EntityTypeBuilder<BoothProduct> builder)
        {
            builder.HasData(
                new BoothProduct { Id = 1, BoothId = 4, ProductId = 17, Quantity = 50 },
                new BoothProduct { Id = 2, BoothId = 4, ProductId = 18, Quantity = 50 },
                new BoothProduct { Id = 3, BoothId = 4, ProductId = 19, Quantity = 50 },
                new BoothProduct { Id = 4, BoothId = 4, ProductId = 20, Quantity = 50 },
                new BoothProduct { Id = 5, BoothId = 4, ProductId = 22, Quantity = 50 },
                new BoothProduct { Id = 6, BoothId = 4, ProductId = 23, Quantity = 50 },
                new BoothProduct { Id = 7, BoothId = 4, ProductId = 24, Quantity = 50 },
                new BoothProduct { Id = 8, BoothId = 4, ProductId = 25, Quantity = 50 },
                new BoothProduct { Id = 9, BoothId = 4, ProductId = 26, Quantity = 50 },
                new BoothProduct { Id = 10, BoothId = 5, ProductId = 1, Quantity = 100 },
                new BoothProduct { Id = 11, BoothId = 5, ProductId = 2, Quantity = 100 },
                new BoothProduct { Id = 12, BoothId = 5, ProductId = 3, Quantity = 100 },
                new BoothProduct { Id = 13, BoothId = 5, ProductId = 4, Quantity = 100 },
                new BoothProduct { Id = 14, BoothId = 5, ProductId = 8, Quantity = 100 },
                new BoothProduct { Id = 15, BoothId = 4, ProductId = 16, Quantity = 50 }

                );
        }
    }
    public class BoothProductsPriceSeedData : IEntityTypeConfiguration<BoothProductsPrice>
    {
        public void Configure(EntityTypeBuilder<BoothProductsPrice> builder)
        {
            builder.HasData(
                new BoothProductsPrice { Id = 1, BoothProductId = 1, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 400000 },
                new BoothProductsPrice { Id = 2, BoothProductId = 2, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 300000 },
                new BoothProductsPrice { Id = 3, BoothProductId = 3, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 300000 },
                new BoothProductsPrice { Id = 4, BoothProductId = 4, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 1000000 },
                new BoothProductsPrice { Id = 5, BoothProductId = 5, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 700000 },
                new BoothProductsPrice { Id = 6, BoothProductId = 6, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 700000 },
                new BoothProductsPrice { Id = 7, BoothProductId = 7, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 700000 },
                new BoothProductsPrice { Id = 8, BoothProductId = 8, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 700000 },
                new BoothProductsPrice { Id = 9, BoothProductId = 9, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 700000 },
                new BoothProductsPrice { Id = 10, BoothProductId = 10, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 500000 },
                new BoothProductsPrice { Id = 11, BoothProductId = 11, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 500000 },
                new BoothProductsPrice { Id = 12, BoothProductId = 12, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 500000 },
                new BoothProductsPrice { Id = 13, BoothProductId = 13, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 20000 },
                new BoothProductsPrice { Id = 14, BoothProductId = 14, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 100000 },
                new BoothProductsPrice { Id = 15, BoothProductId = 15, FromDate = DateTime.Now, ToDate = DateTime.Now + TimeSpan.FromDays(30), Price = 500000 }
                );
        }
    }
    public class CommentSeedData : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(
                new Comment { Id = 1, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 2, Description = "عالی واقعا راضی بودم از همین برا دمکنی و دستگیره استفاده میکنم" },
                new Comment { Id = 2, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 5, Description = "عالی" },
                new Comment { Id = 3, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 3, Satisfaction = 1, Description = "بد بود" },
                new Comment { Id = 4, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 3, Satisfaction = 4, Description = "راضی بودم ولی خاک تو سرشون با بسته بندیشون" },
                new Comment { Id = 5, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 5, Description = "دوسش داشتم" },
                new Comment { Id = 6, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 3, Description = "برا بابام کادو گرفتم هنوز ندیده که بگم خوبه یا بد" },
                new Comment { Id = 7, BoothProductId = 15, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 3, Satisfaction = 3, Description = "بدک نبود" },
                new Comment { Id = 8, BoothProductId = 1, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 3, Satisfaction = 5, Description = "خیلی خوب دمتون گرم" },
                new Comment { Id = 9, BoothProductId = 1, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 2, Description = "مضخرف" },
                new Comment { Id = 10, BoothProductId = 1, Status = GeneralStatus.AwaitConfirmation, CreatedAt = DateTime.Now, CustomerId = 2, Satisfaction = 2, Description = "یه هفتس خریدم به دستم نرسیده" }
                );
        }
    }

}

