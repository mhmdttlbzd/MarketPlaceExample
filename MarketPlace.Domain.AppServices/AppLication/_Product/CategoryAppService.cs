using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Product
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IAttributeTemplateService _attributeTemplateService;
        public CategoryAppService(ICategoryService categoryService, IAttributeTemplateService attributeTemplateService)
        {
            _categoryService = categoryService;
            _attributeTemplateService = attributeTemplateService;
        }
        private async Task<List<CategoryDto>> AllCategories(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllAsync(cancellationToken);
        }
        public async Task<List<CategoryDto>?> GetByParentId(int? id, CancellationToken cancellationToken)
        {
            if (id == -1) { id = null; }
            var all = await AllCategories(cancellationToken);
            return all.Where(c => c.ParentId == id).ToList();
        }
        public async Task<CategoryDto?> GetById(int? id, CancellationToken cancellationToken)
        {
            var all = await AllCategories(cancellationToken);
            return all.FirstOrDefault(c => c.Id == id);
        }
        private async Task<List<AttributeTemplateDto>> GetAttr(int? categoryId,List<AttributeTemplateDto> list, CancellationToken cancellationToken)
        {
            var l =await _attributeTemplateService.GetByCategoryId(categoryId, cancellationToken);
            var category = await GetById(categoryId,cancellationToken);
            list.AddRange(l);
            if (category.ParentId !=null){
                list = await GetAttr(category.ParentId,list,cancellationToken);  
            }
            return list;
        }

        public async Task<List<AttributeTemplateDto>> GetAttrByCategoryId(int id, CancellationToken cancellationToken)
            => await GetAttr(id,new List<AttributeTemplateDto>(), cancellationToken);
    }
}
