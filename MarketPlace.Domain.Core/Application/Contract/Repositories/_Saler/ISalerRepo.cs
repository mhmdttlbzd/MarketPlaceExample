using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Saler
{
    public interface ISalerRepo : IBaseCrudRepository<Saler,SalerInputDto, SalerOutputDto>
    {

    }
}
