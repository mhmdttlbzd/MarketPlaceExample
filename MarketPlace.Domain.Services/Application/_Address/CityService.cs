using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Address
{
    public class CityService : ICityService
    {
        public readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _cityRepo.GetAllAsync(cancellationToken);
        }

        public async Task<CityDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _cityRepo.GetByIdAsync(id, cancellationToken);
        }
        public async Task<List<CityDto>> GetByProvinceId(int id) => await _cityRepo.GetByProvinceId(id);
        public List<CityDto> GetAll() => _cityRepo.GetAll();

    }
}
