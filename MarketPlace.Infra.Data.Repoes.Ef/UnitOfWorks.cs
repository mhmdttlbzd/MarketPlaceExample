using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Infra.Db.SqlServer.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Repoes.Ef
{
    public class UnitOfWorks : IUnitOfWorks
    {
        public readonly MarketPlaceDbContext _dbContext;

        public UnitOfWorks(MarketPlaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
