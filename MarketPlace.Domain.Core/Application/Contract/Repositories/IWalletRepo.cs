using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories
{
	public interface IWalletRepo
	{
		Task<long> GetAllWage(CancellationToken cancellationToken);
        Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken);
        long GetMoneyByUserId(int userId);
        Task Deposit(int userId, long money);
        Task Withdraw(int userId, long money);
        Task CreateTransaction(WalletTransactionDto Input);
        Task CreateAsync(int userId);
    }
}
