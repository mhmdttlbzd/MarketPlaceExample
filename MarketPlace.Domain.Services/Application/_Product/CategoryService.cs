using MarketPlace.Domain.Core;
using MarketPlace.Domain.Core.Application.Contract;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Application._Product
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IApplicationDistributedCache _distributedCache;
        private readonly AppSetting _appSetting;
        public CategoryService(ICategoryRepo categoryRepo, IApplicationDistributedCache distributedCache, AppSetting appSetting)
        {
            _categoryRepo = categoryRepo;
            _distributedCache = distributedCache;
            _appSetting = appSetting;
        }

        public async Task<List<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
        {
            var res =await _distributedCache.GetAsync<CategoryDto>(_appSetting.CategoriesCacheKey);
            if (res == null)
            {
                var categories = await _categoryRepo.GetAllAsync(cancellationToken);
                await _distributedCache.SetAsync(_appSetting.CategoriesCacheKey, categories, 7, TimeSpan.FromHours(2));
                res = categories;
            }

            return res;
        }
        public List<CategoryDto> GetAll()
        {
            var res = _distributedCache.Get<CategoryDto>(_appSetting.CategoriesCacheKey);
            if (res == null)
            {
                var categories = _categoryRepo.GetAll();
                 _distributedCache.Set(_appSetting.CategoriesCacheKey, categories, 7, TimeSpan.FromHours(2));
                res = categories;
            }
            return res;
        }

        public async Task<CategoryDto> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _categoryRepo.GetByIdAsync(id, cancellationToken);
        }
    }
}
