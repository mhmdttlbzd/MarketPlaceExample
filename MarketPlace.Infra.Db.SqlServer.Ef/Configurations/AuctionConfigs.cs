using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Auction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class AuctionConfigs : BaseEntityConfiguration<Auction>
    {
        public override void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Actions");
            builder.HasKey(e => e.Id).HasName("PK_BoothProductsAction");

            builder.Property(e => e.Id);
            builder.Property(e => e.ExpiredTime).HasColumnType("date");

            builder.HasOne(d => d.Product).WithMany(p => p.BoothProductsActions)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProductsAction_Peoducts");
            base.Configure(builder);
        }
    }


    public class AuctionProposalConfigs : BaseEntityConfiguration<AuctionProposal>
    {
        public override void Configure(EntityTypeBuilder<AuctionProposal> builder)
        {
            builder.ToTable("AuctionProposals");
            builder.Property(e => e.Id);

            builder.HasOne(d => d.Auction).WithMany(p => p.AuctionProposals)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_BoothProductsAction");

            builder.HasOne(d => d.Customer).WithMany(p => p.AuctionProposals)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ActionProposals_Customers");
            base.Configure(builder);
        }
    }
}