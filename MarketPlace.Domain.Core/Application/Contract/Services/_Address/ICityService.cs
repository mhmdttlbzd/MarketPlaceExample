using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services._Address
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<CityDto> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
