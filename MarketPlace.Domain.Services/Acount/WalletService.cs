using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services;
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

		public WalletService(IWalletRepo walletRepo)
		{
			_walletRepo = walletRepo;
		}

		public async Task<long> GetAllWage(CancellationToken cancellationToken)
			=> await _walletRepo.GetAllWage(cancellationToken);
	}
}
