using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class CustomerConfigs : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(d => d.Address).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d=>d.AddressId);
        }
    }
}
