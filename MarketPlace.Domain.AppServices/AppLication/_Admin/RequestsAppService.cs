using MarketPlace.Domain.Core.Application.Contract.AppServices._Admin;
using MarketPlace.Domain.Core.Application.Contract.Repositories;
using MarketPlace.Domain.Core.Application.Contract.Services._Booth;
using MarketPlace.Domain.Core.Application.Contract.Services._Picture;
using MarketPlace.Domain.Core.Application.Contract.Services._Product;
using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.AppServices.AppLication._Admin
{
    public class RequestsAppService : IRequestsAppService
    {
        private readonly IProductService _productService;
        private readonly ICommentService _commentService;
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IProductSalerPicService _productSalerPicService;
        private readonly IAuctionPictureService _auctionPictureService;
        private readonly IProductCustomerPicService _productCustomerPicService;

        public RequestsAppService(IProductService productService, ICommentService commentService, IUnitOfWorks unitOfWorks, IProductSalerPicService productSalerPicService, IAuctionPictureService auctionPictureService, IProductCustomerPicService productCustomerPicService)
        {
            _productService = productService;
            _commentService = commentService;
            _unitOfWorks = unitOfWorks;
            _productSalerPicService = productSalerPicService;
            _auctionPictureService = auctionPictureService;
            _productCustomerPicService = productCustomerPicService;
        }



        // Product
        public async Task<List<ProductRequestDto>> GetProductRequests(CancellationToken cancellationToken)
             => await _productService.GetRequests(cancellationToken);

        public async Task<bool> ConfirmProduct(int id, CancellationToken cancellationToken)
        {
            await _productService.ConfirmAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> FaleProduct(int id, CancellationToken cancellationToken)
        {
            await _productService.FaleAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }



        //Comment

        public async Task<List<CommentRequestDto>> GetCommentRequests(CancellationToken cancellationToken)
            => await _commentService.GetRequests(cancellationToken);

        public async Task<bool> ConfirmComment(int id, CancellationToken cancellationToken)
        {
            await _commentService.ConfirmAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> FaleComment(int id, CancellationToken cancellationToken)
        {
            await _commentService.FaleAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }

		// Auction picture
		public async Task<List<AuctionPicRequestDto>> GetAuctionPicRequests(CancellationToken cancellationToken)
	=> await _auctionPictureService.GetRequests(cancellationToken);

		public async Task<bool> ConfirmAuctionPic(int id, CancellationToken cancellationToken)
		{
			await _auctionPictureService.ConfirmAsync(id, cancellationToken);
			var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
			if (res != null && res > 0)
			{
				return true;
			}
			return false;
		}
		public async Task<bool> FaleAuctionPic(int id, CancellationToken cancellationToken)
		{
			await _auctionPictureService.FaleAsync(id, cancellationToken);
			var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
			if (res != null && res > 0)
			{
				return true;
			}
			return false;
		}

		// Saler Picture
		public async Task<List<SalerPicRequestDto>> GetSalerPicRequests(CancellationToken cancellationToken)
=> await _productSalerPicService.GetRequests(cancellationToken);

		public async Task<bool> ConfirmSalerPic(int id, CancellationToken cancellationToken)
		{
			await _productSalerPicService.ConfirmAsync(id, cancellationToken);
			var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
			if (res != null && res > 0)
			{
				return true;
			}
			return false;
		}
		public async Task<bool> FaleSalerPic(int id, CancellationToken cancellationToken)
		{
			await _productSalerPicService.FaleAsync(id, cancellationToken);
			var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
			if (res != null && res > 0)
			{
				return true;
			}
			return false;
		}


        // Customer Picture
        public async Task<List<CustomerPicRequestDto>> GetCustomerPicRequests(CancellationToken cancellationToken)
=> await _productCustomerPicService.GetRequests(cancellationToken);

        public async Task<bool> ConfirmCustomerPic(int id, CancellationToken cancellationToken)
        {
            await _productCustomerPicService.ConfirmAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> FaleCustomerPic(int id, CancellationToken cancellationToken)
        {
            await _productCustomerPicService.FaleAsync(id, cancellationToken);
            var res = await _unitOfWorks.SaveChangesAsync(cancellationToken);
            if (res != null && res > 0)
            {
                return true;
            }
            return false;
        }
    }
}
