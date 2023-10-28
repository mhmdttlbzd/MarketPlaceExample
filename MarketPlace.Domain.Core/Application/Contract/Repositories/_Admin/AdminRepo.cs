

using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Admin;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Admin
{
    public interface IAdminRepo : IBaseCrudRepository<Admin,AdminInputDto,AdminOutputDto>
    {

    }
}
