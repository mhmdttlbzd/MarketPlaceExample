using MarketPlace.Domain.Core.Application.Entities._Auction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.SeedData
{
    public class AuctionSeedData : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.HasData(
                new Auction { Id = 1 , BoothId = 4, BasePrice = 500000 , ProductId = 20, CreatedAt = DateTime.Now,ExpiredTime = DateTime.Now + TimeSpan.FromDays(7),Description = "یک کار ترک عالی با قیمتی باور نکردنی همین کار رو داخل غرفه و جنس ایرانی داریم میفروشیم یک ملیون نخری ضرر کردی"}
                );
        }
    }
}
