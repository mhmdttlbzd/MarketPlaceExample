using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Configurations
{
    public class TransactionConfigs : IEntityTypeConfiguration<WalletTransaction>
    {
        public void Configure(EntityTypeBuilder<WalletTransaction> builder)
        {
            builder.ToTable("Transactions");
        }
    }
    public class WalletConfigs : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");
        }
    }
}
