using Hangfire;
using MarketPlace.Domain.Core.Application.Contract.AppServices._Product;
using MarketPlace.Domain.Core.Application.Contract.Services;
using MarketPlace.Domain.Core.Application.Contract.Services._Auction;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Saler;
using MarketPlace.Domain.Core.Application.Enums;
using MarketPlace.Domain.Services.Application._Picture;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Product
{
    public class AuctionAppService : IAuctionAppService
    {
        private readonly IPictureService _pictureService;
        private readonly UserManager<Seller> _sellerManager;
        private readonly IAuctionService _auctionService;
        private readonly IAuctionPictureService _auctionPictureService;
        private readonly IAuctionProposalService _auctionProposalService;
        private readonly IWalletService _walletService;

        public AuctionAppService(IPictureService pictureService, UserManager<Seller> sellerManager, IAuctionService auctionService, IAuctionPictureService auctionPictureService, IAuctionProposalService auctionProposalService, IWalletService walletService)
        {
            _pictureService = pictureService;
            _sellerManager = sellerManager;
            _auctionService = auctionService;
            _auctionPictureService = auctionPictureService;
            _auctionProposalService = auctionProposalService;
            _walletService = walletService;
        }

        public async Task Create(List<string> paths, AuctionModel model, CancellationToken cancellationToken, string username)
        {
            List<int> picsId = new List<int>();
            foreach (string path in paths)
            {
                int id = await _pictureService.CreateAsync(path, cancellationToken, "کالای قیمت مقطوع");
                picsId.Add(id);
            }
            var user = _sellerManager.FindByNameAsync(username).Result;
            var auctionId = await _auctionService.CreateAsync(new (user.Id, DateTime.Now + TimeSpan.FromDays(model.ExpireDay), model.ProductId,model.BasePrice,model.Description), cancellationToken);
            BackgroundJob.Schedule(
                () => PickWinner(auctionId,user.Id),
                TimeSpan.FromDays(model.ExpireDay));
            foreach (int picId in picsId)
            {
                await _auctionPictureService.CreateAsync(new (picId, auctionId), cancellationToken);
            }
        }

        public async Task PickWinner(int auctionId , int sellerId )
        {
            var proposals = _auctionProposalService.GetProposalsByAuctionId(auctionId).OrderBy(p=> p.Price).Reverse();
            bool win = false;
            if (proposals.Count() != 0)
            {
                foreach (var p in proposals)
                {
                    long walletMoney = _walletService.GetMoneyByUserId(p.CustomerId);
                    if (walletMoney >= p.Price)
                    {
                        var type = SaleType.Auction;
                        await _walletService.AddTransaction(p.CustomerId, sellerId, p.Price,type);
                        win = true; break;
                    }
                }
            }
            if (!win)
            {
                await _auctionService.DeleteAsync(auctionId, new CancellationToken());
            }
        }
    }
}
