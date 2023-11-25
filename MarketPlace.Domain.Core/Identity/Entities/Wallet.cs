using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MarketPlace.Domain.Core.Identity.Entities
{
    public class Wallet
    {
        public int Id { get; set; }
        public long Money { get; set; } 

        public ApplicationUser User { get; set; }
    }
}
