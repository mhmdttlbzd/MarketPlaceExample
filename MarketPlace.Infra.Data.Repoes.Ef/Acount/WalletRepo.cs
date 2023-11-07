using AutoMapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Dtos;
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
		private readonly IMapper _mapper;

		public WalletRepo(MarketPlaceDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
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
		public async Task<List<WalletTransactionOutputDto>> GetAllWalletTransactions(CancellationToken cancellationToken)
			=> _mapper.Map<List<WalletTransactionOutputDto>>(await _dbContext.Set<WalletTransaction>().AsNoTracking().ToListAsync(cancellationToken));

	}
}
