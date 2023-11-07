using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Identity.Entities;
using MarketPlace.Infra.Db.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef.Acount
{
    public class UserRepo : IUserRepo
    {
        private readonly MarketPlaceDbContext _dbContext;

        public UserRepo(MarketPlaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Update(ApplicationUser input)
        {
            var user = await _dbContext.Set<ApplicationUser>().FirstAsync();
            user.Status = input.Status;
            user.Name = input.Name;
            user.Email = input.Email;
        }
    }
}
