using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface IBoothProductAppService
    {
        Task Create(List<string> paths, BoothProductModel model, CancellationToken cancellationToken, string username);
        List<GeneralBoothProductDto> GetBestProducts(int Count);
        Task<BoothProductOutputDto> GetById(int id, CancellationToken cancellationToken);
        Task AddToCart(string userName, int boothProductId, CancellationToken cancellationToken);
        List<GeneralBoothProductDto> GetByCategoryId(int id);
        List<GeneralBoothProductDto> GetSellerProducts(int sellerId);
        Task Delete(int id, CancellationToken cancellationToken);
        Task UpdateAsync(List<string> paths, BoothProductModel model, CancellationToken cancellationToken, string username);
        List<ProductPriceDto> GetPricesByProductId(int productId);
        Task AddCustomerPictures(List<string> paths, int productId, string username, CancellationToken cancellationToken);
    }
}
