using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class BoothConfigs : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> builder)
        {
            builder.ToTable("Booths");
            builder.HasKey(e => e.Id).HasName("PK_Booth");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.ShopAddress).WithMany(p => p.Booths)
                .HasForeignKey(d => d.ShopAddressId)
                .HasConstraintName("FK_Booth_Address");

            builder.HasOne(d => d.Saler).WithOne(p => p.Booth)
                .HasForeignKey<Booth>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booth_Saler");
        }
    }
    public class BoothProductConfigs : BaseEntityConfiguration<BoothProduct>
    {
        public override void Configure(EntityTypeBuilder<BoothProduct> builder)
        {
            builder.ToTable("BoothProducts");
            builder.HasKey(e => e.Id).HasName("PK_BoothProducts");

            builder.Property(e => e.Id);

            builder.HasOne(d => d.Booth).WithMany(p => p.BoothsProducts)
                .HasForeignKey(d => d.BoothId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProducts_Booth");

            builder.HasOne(d => d.Product).WithMany(p => p.BoothsProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProducts_Peoducts");
            base.Configure(builder);
        }
    }
    public class BoothProductsPriceConfigs : IEntityTypeConfiguration<BoothProductsPrice>
    {
        public void Configure(EntityTypeBuilder<BoothProductsPrice> builder)
        {
            builder.ToTable("BoothProductsPrices");
            builder.Property(e => e.Id);
            builder.Property(e => e.FromDate).HasColumnType("date");
            builder.Property(e => e.ToDate).HasColumnType("date");

            builder.HasOne(d => d.BoothProduct).WithMany(p => p.BoothProductsPrices)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BoothProductsPrices_BoothProducts");
        }
    }

    public class CommentConfigs : BaseEntityConfiguration<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(e => e.Id).HasName("PK_Comment");

            builder.Property(e => e.Id);
            builder.Property(e => e.Description).HasMaxLength(500);

            builder.HasOne(d => d.BoothProduct).WithMany(p => p.Comments)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Comment_BoothProducts");

            builder.HasOne(d => d.Customer).WithMany(p => p.Comments)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK_Comment_Customers");
            builder.HasCheckConstraint("0 to 5", "([Satisfaction]<=(5) AND [Satisfaction]>=(0))");
            base.Configure(builder);
        }
    }
}
