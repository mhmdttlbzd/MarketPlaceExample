using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Identity.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Saler
{
    public interface ISalerRepo : IBaseCrudRepository<Seller,SellerInputDto, SellerOutputDto>
    {
		int AllSellersCount();
        Task<List<GeneralSellerDto>> GetGeneralSalers(CancellationToken cancellationToken);
        byte GetWagePercent(int sellerId);
        Task UpdateType(int sellerId, int sellerTypeId);
    }
}
