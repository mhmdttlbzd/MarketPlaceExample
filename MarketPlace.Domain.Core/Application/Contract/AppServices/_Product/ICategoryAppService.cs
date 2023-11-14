using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Product
{
    public interface ICategoryAppService
    {
        Task<List<CategoryDto>?> GetByParentId(int? id, CancellationToken cancellationToken);
        Task<CategoryDto?> GetById(int? id, CancellationToken cancellationToken);
        Task<List<AttributeTemplateDto>> GetAttrByCategoryId(int id, CancellationToken cancellationToken);

    }
}
