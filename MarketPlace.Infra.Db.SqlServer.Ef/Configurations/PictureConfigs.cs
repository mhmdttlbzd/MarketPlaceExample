using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class PictureConfigs : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.ToTable("Pictures");
            builder.Property(e => e.Alt).HasMaxLength(50);
            builder.Property(e => e.Path)
                .HasMaxLength(250)
                .IsUnicode(false);
        }
    }
    public class AuctionPictureConfigs : BaseEntityConfiguration<AuctionPicture>
    {
        public override void Configure(EntityTypeBuilder<AuctionPicture> builder)
        {
            builder.ToTable("AuctionPictures");

            builder.HasOne(d => d.Auction).WithMany(p => p.PicturesActions)
                .HasForeignKey(d => d.AuctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PicturesActions_BoothProductsAction");

            builder.HasOne(d => d.Picture).WithMany(p => p.PicturesActions)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PicturesActions_Pictures");
            base.Configure(builder);
        }
    }
    public class ProductCustomerPicConfigs : BaseEntityConfiguration<ProductCustomerPic>
    {
        public override void Configure(EntityTypeBuilder<ProductCustomerPic> builder)
        {
            builder.ToTable("ProductCustomerPics");
            builder.HasKey(e => e.Id).HasName("PK_CustomerProductPices");


            builder.HasOne(d => d.BoothProduct).WithMany(p => p.CustomersProductPices)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProductPices_BoothProducts");

            builder.HasOne(d => d.Picture).WithMany(p => p.CustomersProductPices)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerProductPices_Pictures");
            base.Configure(builder);
        }
    }
    public class ProductSalerPicConfigs : BaseEntityConfiguration<ProductSalerPic>
    {
        public override void Configure(EntityTypeBuilder<ProductSalerPic> builder)
        {
            builder.ToTable("ProductSalerPics");
            builder.HasKey(e => e.Id).HasName("PK_SalerProductPic");


            builder.HasOne(d => d.BoothProduct).WithMany(p => p.SalersProductPics)
                .HasForeignKey(d => d.BoothProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalerProductPic_BoothProducts");

            builder.HasOne(d => d.Picture).WithMany(p => p.SalersProductPics)
                .HasForeignKey(d => d.PictureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalerProductPic_Pictures");
            base.Configure(builder);
        }
    }
}
