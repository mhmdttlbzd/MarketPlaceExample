using MarketPlace.Domain.Core.Application.Entities._Auction;
using MarketPlace.Domain.Core.Application.Entities._Customer;
using MarketPlace.Domain.Core.Application.Entities._Order;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Domain.Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Entities
{
    public partial class WalletTransaction
    {
        public int Id { get; set; }
        public int Wage { get; set; }
        public long PaidPrice { get; set; }
        public int FromWalletId { get; set; }
        public int ToWalletId { get; set; }
        public DateTime Time { get; set; }
        public SaleType SaleType { get; set; }
    }
}
