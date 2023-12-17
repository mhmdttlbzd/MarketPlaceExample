
using MarketPlace.Domain.Core.Application.Contract.AppServices._Seller;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Order;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Seller
{
    public class BoothAppService : IBoothAppService
    {
        private readonly UserManager<Seller> _sellerManager;
        private readonly IBoothService _boothService;
        private readonly IAuctionService _auctionService;
        private readonly IOrderLineService _orderLineService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IBoothProductService _boothProductService;

        public BoothAppService(UserManager<Seller> userManager, IBoothService boothService, IAuctionService auctionService, IOrderLineService orderLineService, IUnitOfWorks unitOfWorks, IBoothProductService boothProductService)
        {
            _sellerManager = userManager;
            _boothService = boothService;
            _auctionService = auctionService;
            _orderLineService = orderLineService;
            _unitOfWorks = unitOfWorks;
            _boothProductService = boothProductService;
        }

        public async Task<BoothModel> GetBoothPanelInformation(string userName, CancellationToken cancellationToken)
        {
            var seller = await _sellerManager.FindByNameAsync(userName);
            var booth = await _boothService.GetGeneralBoothById(seller.Id, cancellationToken);
            var actions = _auctionService.GetGeneralAuctionBySellerId(seller.Id);
            var res = new BoothModel
            {
                Id = seller.Id,
                Name = booth.Name,
                SellerName = seller.Name,
                SellerFamily = seller.Family,
                SellerEmail = seller.Email,
                CityName = booth.CityName,
                Address = booth.Address,
                PostalCode = booth.PostalCode,
                BoothProductsCount = booth.BoothProductsCount,
                TotalSales = booth.TotalSales,
                Auctions = actions
            };
            return res;
        }
        public async Task<List<SaleOrderLineDto>> GetSaledProducts(string userName, CancellationToken cancellationToken)
        {
            var seller = await _sellerManager.FindByNameAsync(userName);
            return await _orderLineService.GetSaledProducts(seller.Id, cancellationToken);
        }

        public List<GeneralBoothDto> GetByCategoryId(int id) => _boothService.GetByCategoryId(id);

        public async Task<List<GeneralBoothProductDto>> GetSellerProducts(string userName)
        {
            var user = await _sellerManager.FindByNameAsync(userName);
            var res = _boothProductService.GetSellerProducts(user.Id);
            return res;
        }
    }
}
