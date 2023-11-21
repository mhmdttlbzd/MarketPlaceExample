using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Booth;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Booth
{
    public interface IBoothRepo : IBaseCrudRepository<Booth, BoothInputDto, BoothOutputDto>
    {
        Task<GeneralBoothDto> GetGeneralBoothById(int id, CancellationToken cancellationToken);
    }
}