using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Product
{
    public interface IProductRepo : IBaseCrudRepository<Product,ProductInputDto, ProductOutputDto>
    {
		int GetCount();
		int AllRequestsCount();
        Task<List<ProductRequestDto>> GetRequests(CancellationToken cancellationToken);
        Task FaleAsync(int id, CancellationToken cancellationToken);
        Task ConfirmAsync(int id, CancellationToken cancellationToken);
    }
}
