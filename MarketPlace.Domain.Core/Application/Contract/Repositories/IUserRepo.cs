using MarketPlace.Domain.Core.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories
{
    public interface IUserRepo
    {
        Task Update(ApplicationUser input);
    }
}
