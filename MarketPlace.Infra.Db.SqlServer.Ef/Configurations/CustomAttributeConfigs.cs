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
            builder.Property(e => e.Title).HasMaxLength(50);

            builder.HasMany(d => d.CategoryCustomAttributes).WithOne(d => d.CustomAttributeTemplate)
                .HasForeignKey(d => d.CustomAttributeTemplateId);
        }
    }
    public class CategoryAttributeConfigs : IEntityTypeConfiguration<CategoryCustomAttribute>
    {
        public void Configure(EntityTypeBuilder<CategoryCustomAttribute> builder)
        {
            builder.ToTable("CategoryCustomAttribute");
            builder.HasKey(d => d.Id);
            //builder.HasNoKey();
            builder.HasOne(d => d.Category).WithMany(p => p.CategoryCustomAttributes)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryCustomAttribute_Category");

            builder.HasOne(d => d.CustomAttributeTemplate).WithMany(p => p.CategoryCustomAttributes)
                .HasForeignKey(d => d.CustomAttributeTemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CategoryCustomAttribute_CustomAttributeTemplate");
        }
    }
     
    public class ProductAttributeConfigs : BaseEntityConfiguration<ProductsCustomAttribute>
    {
        public override void Configure(EntityTypeBuilder<ProductsCustomAttribute> builder)
        {
            builder.ToTable(" ProductsCustomAttributes");
            builder.HasKey(e => e.Id).HasName("PK_ProductCustomAttribute");

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
