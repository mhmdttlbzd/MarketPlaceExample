using MarketPlace.Domain.Core.Application.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; } = null!;
        public string Family { get; set; } = null!;
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
