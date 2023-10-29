using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class AttributeTemplateConfigs : IEntityTypeConfiguration<CustomAttributeTemplate>
    {
        public void Configure(EntityTypeBuilder<CustomAttributeTemplate> builder)
        {
            builder.ToTable("CustomAttributeTemplates");
            builder.HasKey(e => e.Id).HasName("PK_CustomAttributeTemlate");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasOne(d => d.Category).WithMany(p => p.CustomAttributeTemlates)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomAttributeTemlate_Categories");
        }
    }

    public class ProductAttribute : BaseEntityConfiguration<ProductsCustomAttribute> 
    {
        public override void Configure(EntityTypeBuilder<ProductsCustomAttribute> builder)
        {
            builder.ToTable(" ProductsCustomAttributes");
            builder.HasKey(e => e.Id).HasName("PK_ProductCustomAttribute");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.AttributeValue).HasMaxLength(100);

            builder.HasOne(d => d.Attribute).WithMany(p => p.ProductsCustomAttributes)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttribute_CustomAttributeTemlate");

            builder.HasOne(d => d.Product).WithMany(p => p.ProductsCustomAttributes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCustomAttribute_Peoducts");
            base.Configure(builder);
        }
    }
}
