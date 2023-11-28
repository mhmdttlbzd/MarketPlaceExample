using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Booth
{
    public interface IBoothProductRepo : IBaseCrudRepository<BoothProduct, BoothProductInputDto, BoothProductOutputDto>
    {
        List<GeneralBoothProductDto> GetBestProducts(int Count);
        List<GeneralBoothProductDto> GetByCategoryId(int id);
        List<GeneralBoothProductDto> GetSellerProducts(int sellerId);
    }
}
