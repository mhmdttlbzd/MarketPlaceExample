using MarketPlace.Domain.Core.Application.Entities._Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class AdminConfigs : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.ToTable("Admins");
            builder.HasKey(e => e.Id).HasName("PK_Admin");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(d => d.PersonalCode).HasMaxLength(10);
        }
    }
}
