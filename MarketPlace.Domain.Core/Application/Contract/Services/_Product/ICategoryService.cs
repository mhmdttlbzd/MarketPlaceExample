using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Product
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
