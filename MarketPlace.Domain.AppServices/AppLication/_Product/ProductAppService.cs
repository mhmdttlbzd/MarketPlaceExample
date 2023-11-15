using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._CustomAttribute;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Prodoct;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Domain.Core.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Product
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IProductAttributeService _productAttributeService;

        public ProductAppService(IProductService productService, IUnitOfWorks unitOfWorks, UserManager<ApplicationUser> userManager, IProductAttributeService productAttributeService)
        {
            _productService = productService;
            _unitOfWorks = unitOfWorks;
            _userManager = userManager;
            _productAttributeService = productAttributeService;
        }

        public async Task<List<ProductOutputDto>> GetAllProducts(CancellationToken cancellationToken)
        {
            return await _productService.GetAllAsync(cancellationToken);
        }

        public async Task<bool> UpdateProduct( int id ,string name , List<ProductAttrModel> productAttrModels, int categoryId,CancellationToken cancellationToken)
        { 

            await _productService.UpdateAsync(new ProductInputDto(name,categoryId),id,cancellationToken);
            foreach (var item in productAttrModels)
            {
                var attr = await _productAttributeService.GetByIdAsync(item.AttributeId, cancellationToken);
                await _productAttributeService.UpdateAsync(new ProductAttributeInputDto(
                    attr.ProductId, attr.AttributeId, item.AttributeValue
                    )
                , item.AttributeId, cancellationToken);
            }
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<ProductOutputDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    => await _productService.GetByIdAsync(id, cancellationToken);


        public async Task<bool> CreateProduct(string username, string name,List<ProductAttrModel> productAttrModels , int categoryId, CancellationToken cancellationToken)
        {
            var status = GeneralStatus.AwaitConfirmation;
            if (await _userManager.IsInRoleAsync(await _userManager.FindByNameAsync(username), "Admin"))
            {
                status = GeneralStatus.Confirmed;
            }
            var productId = await _productService.CreateAsync(new ProductInputDto(name, categoryId,status),  cancellationToken);
            foreach (var attr in productAttrModels)
            {
                await _productAttributeService.CreateAsync(new ProductAttributeInputDto(
                    productId, attr.AttributeId, attr.AttributeValue), cancellationToken);
            }
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);

            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }
    }
}
