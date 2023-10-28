using MarketPlace.Domain.Core.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class MainAddressConfigs : BaseEntityConfiguration<MainAddress>
    {
        public override void Configure(EntityTypeBuilder<MainAddress> builder)
        {
            builder.ToTable("MainAddresses");
            builder.HasKey(e => e.Id).HasName("PK_Address");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("Address");

            builder.HasOne(d => d.City).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Address_City");
            base.Configure(builder);
        }
    }
    public class CityConfigs : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(e => e.Id).HasName("PK_City");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.Province).WithMany(p => p.Cities)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_City_Provience");
        }
    }
    public class ProvinceConfigs : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable("Provinces");
            builder.HasKey(e => e.Id).HasName("PK_Provience");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Name).HasMaxLength(25);
        }
    }
}
