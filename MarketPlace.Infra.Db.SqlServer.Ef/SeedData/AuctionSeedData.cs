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
                new Auction { Id = 1, BoothId = 4, BasePrice = 500000, ProductId = 20, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک کار ترک عالی با قیمتی باور نکردنی همین کار رو داخل غرفه و جنس ایرانی داریم میفروشیم یک ملیون نخری ضرر کردی" },
                new Auction { Id = 2, BoothId = 4, BasePrice = 100000, ProductId = 20, CreatedAt = DateTime.Now - TimeSpan.FromDays(8), ExpiredTime = DateTime.Now - TimeSpan.FromDays(1), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" },
                new Auction { Id = 3, BoothId = 4, BasePrice = 100000, ProductId = 22, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" },
                new Auction { Id = 4, BoothId = 4, BasePrice = 100000, ProductId = 23, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" },
                new Auction { Id = 5, BoothId = 6, BasePrice = 100000, ProductId = 24, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" },
                new Auction { Id = 6, BoothId = 6, BasePrice = 100000, ProductId = 25, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" },
                new Auction { Id = 7, BoothId = 6, BasePrice = 100000, ProductId = 26, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7), Description = "یک پیشنهاد باور نکردنی برای افراد خوش سلیقه و لوکس پسند" }
                );
        }

    }
    public class AuctionProposalSeedData : IEntityTypeConfiguration<AuctionProposal>
    {
        public void Configure(EntityTypeBuilder<AuctionProposal> builder)
        {
            builder.HasData(
                new AuctionProposal { Id = 1, AuctionId = 1, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 550000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 2, AuctionId = 1, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 520000, CustomerId = 3, IsTopProposal = false },
                new AuctionProposal { Id = 3, AuctionId = 3, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 120000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 4, AuctionId = 3, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 110000, CustomerId = 3, IsTopProposal = false },

                new AuctionProposal { Id = 5, AuctionId = 4, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 120000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 6, AuctionId = 4, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 110000, CustomerId = 3, IsTopProposal = false },

                new AuctionProposal { Id = 7, AuctionId = 5, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 120000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 8, AuctionId = 5, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 110000, CustomerId = 3, IsTopProposal = false },

                new AuctionProposal { Id = 9, AuctionId = 6, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 120000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 10, AuctionId = 6, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 110000, CustomerId = 3, IsTopProposal = false },

                new AuctionProposal { Id = 11, AuctionId = 7, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 120000, CustomerId = 3, IsTopProposal = true },
                new AuctionProposal { Id = 12, AuctionId = 7, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 110000, CustomerId = 3, IsTopProposal = false }
                );
        }


    }
}
