using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services
{
	public interface IWalletService
	{
		Task<long> GetAllWage(CancellationToken cancellationToken);
        Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken);
        Task Withdraw(int userId, long money);
        Task Deposit(int userId, long money);
        long GetMoneyByUserId(int userId);
        Task AddTransaction(int customerId, int sellerId, long price, SaleType type);
    }
}
