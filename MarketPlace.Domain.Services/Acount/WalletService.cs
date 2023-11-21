using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Booth;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Saler;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Acount
{
	public class WalletService : IWalletService
	{
		private readonly IWalletRepo _walletRepo;
		private readonly ISalerRepo _sellerRepo;
		private readonly ISalerTypeRepo _salerTypeRepo;
		private readonly IBoothRepo _boothRepo;
		private readonly IUnitOfWorks _unitOfWorks;
        public WalletService(IWalletRepo walletRepo, ISalerRepo sellerRepo, ISalerTypeRepo salerTypeRepo, IBoothRepo boothRepo, IUnitOfWorks unitOfWorks)
        {
            _walletRepo = walletRepo;
            _sellerRepo = sellerRepo;
            _salerTypeRepo = salerTypeRepo;
            _boothRepo = boothRepo;
            _unitOfWorks = unitOfWorks;
        }

        public async Task<long> GetAllWage(CancellationToken cancellationToken)
			=> await _walletRepo.GetAllWage(cancellationToken);
		public async Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken)
			=> await _walletRepo.GetAllWalletTransactions(cancellationToken);
		public long GetMoneyByUserId(int userId) => _walletRepo.GetMoneyByUserId(userId);
		public async Task Deposit(int userId, long money) => await _walletRepo.Deposit(userId, money);
		public async Task Withdraw(int userId, long money) => await _walletRepo.Withdraw(userId, money);

		public async Task AddTransaction(int customerId,int sellerId,long price,SaleType type)
		{
            byte wagePercent = _sellerRepo.GetWagePercent(sellerId);
            int wage = (int)(price * wagePercent / 100);
            await Withdraw(customerId, price);
            await Deposit(sellerId, price - (price * wagePercent / 100));
            await Deposit(1, price * wagePercent / 100);
			await _walletRepo.CreateTransaction(new WalletTransactionDto
			{
				SaleType = type,
				PaidPrice = price,
				FromWalletId = customerId,
				ToWalletId = sellerId,
				Time = DateTime.Now,
				Wage = wage
			});
			var sellerTypes = _salerTypeRepo.GetAll().OrderBy(s => s.BaseSalesMoney);
			var sale = await _boothRepo.GetSalesMoney(sellerId);
			foreach (var sellerType in sellerTypes)
			{
				if (sale >= sellerType.BaseSalesMoney)
				{
					await _sellerRepo.UpdateType(sellerId, sellerType.Id);
				}
			}
			_unitOfWorks.SaveChanges();
        }
    }
}
