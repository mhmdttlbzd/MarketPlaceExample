using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class SellerConfigs : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasOne(d => d.SellerType).WithMany(p => p.Salers)
                .HasForeignKey(d => d.SellerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Seller_SellerTypes");
        }
    }

    public class SalerTypeConfigs : IEntityTypeConfiguration<SellerType>
    {
        public void Configure(EntityTypeBuilder<SellerType> builder)
        {
            builder.ToTable("SellerTypes");
            builder.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.HasCheckConstraint("0 to 100", "([WagePercent]<=(100) AND [WagePercent]>=(0))");
        }
    }
}
