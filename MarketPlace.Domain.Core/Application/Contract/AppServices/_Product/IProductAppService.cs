using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface IProductAppService
    {
        Task<List<ProductOutputDto>> GetAllProducts(CancellationToken cancellationToken);
        Task<bool> UpdateProduct(int id, string name, List<ProductAttrModel> productAttrModels, int categoryId, CancellationToken cancellationToken);
        Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<bool> CreateProduct(string username, string name, List<ProductAttrModel> productAttrModels, int categoryId, CancellationToken cancellationToken);
    }
}
