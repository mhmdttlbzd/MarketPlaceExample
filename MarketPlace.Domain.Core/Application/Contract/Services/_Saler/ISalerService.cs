using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Saler
{
    public interface ISalerService
    {
        Task<int> CreateAsync(SellerInputDto input, CancellationToken cancellationToken);
        Task<List<SellerOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<SellerOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(SellerInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        int AllSalersCount();
        Task<List<GeneralSellerDto>> GetGeneralSellers(CancellationToken cancellationToken);
        byte GetWagePercent(int sellerId);

        Task<GeneralSellerDto> GetGeneralSeller(int id);
    }
}
