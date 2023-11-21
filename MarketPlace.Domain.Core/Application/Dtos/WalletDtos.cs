using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    public record WalletTransactionDto
    {
        public int Wage { get; set; }
        public long PaidPrice { get; set; }
        public int FromWalletId { get; set; }
        public int ToWalletId { get; set; }
        public DateTime Time { get; set; }
        public SaleType SaleType { get; set; }
    }
}
