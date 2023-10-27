using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._CustomAttribute
{
    public interface IAttributeTemplateRepo
    {
        Task<List<AttributeTemplateDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<AttributeTemplateDto> GetByIdAsync(int id,CancellationToken cancellationToken);
    }
}
