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
                new Auction { Id = 1 , BoothId = 4, BasePrice = 500000 , ProductId = 20, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), ExpiredTime = DateTime.Now + TimeSpan.FromDays(7),Description = "یک کار ترک عالی با قیمتی باور نکردنی همین کار رو داخل غرفه و جنس ایرانی داریم میفروشیم یک ملیون نخری ضرر کردی"},
                new Auction { Id = 2 , BoothId = 4, BasePrice = 100000 , ProductId = 21, CreatedAt = DateTime.Now - TimeSpan.FromDays(8), ExpiredTime = DateTime.Now - TimeSpan.FromDays(1), Description = "ازین پیرهن فقط یکی مونده" }
                );
        }
        
    }
    public class AuctionProposalSeedData : IEntityTypeConfiguration<AuctionProposal>
    {
		public void Configure(EntityTypeBuilder<AuctionProposal> builder)
		{
            builder.HasData(
                new AuctionProposal { Id = 1, AuctionId = 1, CreatedAt = DateTime.Now - TimeSpan.FromDays(1), Price = 550000, CustomerId = 3, IsTopProposal = true},
                new AuctionProposal { Id = 2, AuctionId = 1, CreatedAt = DateTime.Now - TimeSpan.FromDays(2), Price = 520000, CustomerId = 3, IsTopProposal = false }
				);
		}

		
    }
}
