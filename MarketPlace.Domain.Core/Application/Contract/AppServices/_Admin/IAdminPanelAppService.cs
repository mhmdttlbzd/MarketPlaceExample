using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Admin
{
	public interface IAdminPanelAppService
	{
		Task<AdminPanelInformationDto> GetInformation(CancellationToken cancellationToken);
		Task<List<SaleOrderLineDto>> GetSaledProducts(CancellationToken cancellationToken);
        Task<List<WalletTransactionDto>> GetAllWalletTransactions(CancellationToken cancellationToken);
		Task<List<GeneralCustomerDto>> GetAllCustomers(CancellationToken cancellationToken);
		Task<List<GeneralSellerDto>> GetAllSalers(CancellationToken cancellationToken);

        Task ActiveUser(int id, CancellationToken cancellationToken);
		Task DeActiveUser(int id, CancellationToken cancellationToken);
    }
}
