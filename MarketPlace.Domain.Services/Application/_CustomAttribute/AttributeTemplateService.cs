using MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._CustomAttribute
{
    public class AttributeTemplateService : IAttributeTemplateService
    {
        private readonly IAttributeTemplateRepo _attributeTemplateRepo;

        public AttributeTemplateService(IAttributeTemplateRepo attributeTemplateRepo)
        {
            _attributeTemplateRepo = attributeTemplateRepo;
        }

        public async Task<int> CreateAsync(AttributeTemplateDto input, CancellationToken cancellationToken)
        {
            return await _attributeTemplateRepo.CreateAsync(input, cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _attributeTemplateRepo.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<AttributeTemplateDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _attributeTemplateRepo.GetAllAsync(cancellationToken);
        }

        public async Task<AttributeTemplateDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _attributeTemplateRepo.GetByIdAsync(id, cancellationToken);
        }

        public async Task UpdateAsync(AttributeTemplateDto input, int id, CancellationToken cancellationToken)
        {
            await _attributeTemplateRepo.UpdateAsync(input, id, cancellationToken);
        }
        public async Task<List<AttributeTemplateDto>> GetByCategoryId(int? id, CancellationToken cancellationToken)
            => await _attributeTemplateRepo.GetByCategoryId(id, cancellationToken);
    }
}
