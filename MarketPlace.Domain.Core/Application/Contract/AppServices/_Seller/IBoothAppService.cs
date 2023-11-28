using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Seller
{
    public interface IBoothAppService
    {
        Task<BoothModel> GetBoothPanelInformation(string userName, CancellationToken cancellationToken);
        Task<List<SaleOrderLineDto>> GetSaledProducts(string userName, CancellationToken cancellationToken);
        Task DeleteAuction(int id, CancellationToken cancellationToken);
        List<GeneralBoothDto> GetByCategoryId(int id);
    }
}
