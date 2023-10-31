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
        Task<int> CreateAsync(AttributeTemplateInputDto input, CancellationToken cancellationToken);
        Task<List<AttributeTemplateOutputDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AttributeTemplateOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task UpdateAsync(AttributeTemplateInputDto input, int id, CancellationToken cancellationToken);
        Task DeleteAsync(int id, CancellationToken cancellationToken);
    }
}
