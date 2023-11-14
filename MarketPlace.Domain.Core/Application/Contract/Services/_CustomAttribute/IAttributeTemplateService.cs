using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute
{
    public interface IAttributeTemplateService
    {
        Task<int> CreateAsync(AttributeTemplateDto input, CancellationToken cancellationToken);
        Task<List<AttributeTemplateDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AttributeTemplateDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AttributeTemplateDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
        Task<List<AttributeTemplateDto>> GetByCategoryId(int? id, CancellationToken cancellationToken);
    }
}
