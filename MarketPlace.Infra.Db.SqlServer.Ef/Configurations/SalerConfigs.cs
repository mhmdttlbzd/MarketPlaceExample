using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class SalerConfigs : IEntityTypeConfiguration<Saler>
    {
        public void Configure(EntityTypeBuilder<Saler> builder)
        {
            builder.ToTable("Salers");
            builder.HasKey(e => e.Id).HasName("PK_Saler");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.SalerType).WithMany(p => p.Salers)
                .HasForeignKey(d => d.SalerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Saler_SalerTypes");
        }
    }

    public class SalerTypeConfigs : IEntityTypeConfiguration<SalerType>
    {
        public void Configure(EntityTypeBuilder<SalerType> builder)
        {
            builder.ToTable("SalerTypes");
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Title)
                .HasMaxLength(10)
                .IsFixedLength();
            builder.HasCheckConstraint("0 to 100", "([TaskPercent]<=(100) AND [TaskPercent]>=(0))");
        }
    }
}
