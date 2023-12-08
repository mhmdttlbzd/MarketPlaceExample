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
using System.Threading;
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

		public async Task CreateAsync(int userId)
		{
			await _dbContext.Set<Wallet>().AddAsync(new Wallet
			{
				Id = userId,
				Money = 0
			});
			await _dbContext.SaveChangesAsync();
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
		public async Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken)
			=> _mapper.Map<List<WalletTransactionDto>>(await _dbContext.Set<WalletTransaction>().AsNoTracking().ToListAsync(cancellationToken));


		public long GetMoneyByUserId(int userId)
			=> _dbContext.Set<Wallet>().AsNoTracking().FirstOrDefault(w => w.Id == userId).Money;

		public async Task Deposit(int userId,long money)
		{
			var wallet = await _dbContext.Set<Wallet>().FirstOrDefaultAsync(w => w.Id == userId);
			wallet.Money += money;
		} 
		public async Task Withdraw(int userId,long money)
		{
			var wallet = await _dbContext.Set<Wallet>().FirstOrDefaultAsync(w => w.Id == userId);
			wallet.Money -= money;
		} 

		public async Task CreateTransaction(WalletTransactionDto Input)
		{
            var entity = _mapper.Map<WalletTransaction>(Input);
            await _dbContext.Set<WalletTransaction>().AddAsync(entity);
        }

	}
}
