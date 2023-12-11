using MarketPlace.Domain.Core;
using MarketPlace.Domain.Core.Application.Contract;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Address;
using MarketPlace.Domain.Core.Application.Contract.Services._Address;
using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Domain.Services.Application._Address
{
    public class CityService : ICityService
    {
        public readonly ICityRepo _cityRepo;
        private readonly IApplicationDistributedCache _distributedCache;
        private readonly AppSetting _appSetting;

        public CityService(ICityRepo cityRepo, IApplicationDistributedCache distributedCache, AppSetting appSetting)
        {
            _cityRepo = cityRepo;
            _distributedCache = distributedCache;
            _appSetting = appSetting;
        }

        public async Task<List<CityDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res = await _distributedCache.GetAsync<CityDto>(_appSetting.CitiesCacheKey);
            if (res == null)
            {
                var categories = await _cityRepo.GetAllAsync(cancellationToken);
                await _distributedCache.SetAsync(_appSetting.CitiesCacheKey, categories, 7, TimeSpan.FromHours(2));
                res = categories;
            }

            return res;
        }
        public List<CityDto> GetAll()
        {
            var res =  _distributedCache.Get<CityDto>(_appSetting.CitiesCacheKey);
            if (res == null)
            {
                var categories =  _cityRepo.GetAll();
                _distributedCache.Set(_appSetting.CitiesCacheKey, categories, 7, TimeSpan.FromHours(2));
                res = categories;
            }

            return res;
        }
        public async Task<CityDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _cityRepo.GetByIdAsync(id, cancellationToken);
        }
        public async Task<List<CityDto>> GetByProvinceId(int id)
        {
            var all = GetAll();
            return all.Where(c => c.Id == id).ToList();
        }

    }
}
