using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Entities;
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
	public class WalletRepo : IWalletRepo
	{
		private readonly MarketPlaceDbContext _dbContext;

		public WalletRepo(MarketPlaceDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<long> GetAllWage(CancellationToken cancellationToken)
		{
			int res = 0;
			var wageList = await _dbContext.Set<WalletTransaction>().Select(w => w.Wage).ToListAsync(cancellationToken);
			foreach (var wage in wageList)
			{
				res += wage;
			}
			return res;
		}
	}
}
