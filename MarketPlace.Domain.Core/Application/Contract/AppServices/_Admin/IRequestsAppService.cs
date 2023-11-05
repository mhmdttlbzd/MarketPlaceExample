using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.AppServices._Admin
{
    public interface IRequestsAppService
    {
        Task<List<ProductRequestDto>> GetProductRequests(CancellationToken cancellationToken);
        Task<bool> FaleProduct(int id, CancellationToken cancellationToken);
        Task<bool> ConfirmProduct(int id, CancellationToken cancellationToken);
        Task<List<CommentRequestDto>> GetCommentRequests(CancellationToken cancellationToken);
        Task<bool> FaleComment(int id, CancellationToken cancellationToken);
        Task<bool> ConfirmComment(int id, CancellationToken cancellationToken);
        Task<bool> FaleSalerPic(int id, CancellationToken cancellationToken);
        Task<bool> ConfirmSalerPic(int id, CancellationToken cancellationToken);
		Task<List<SalerPicRequestDto>> GetSalerPicRequests(CancellationToken cancellationToken);
        Task<bool> FaleAuctionPic(int id, CancellationToken cancellationToken);
        Task<bool> ConfirmAuctionPic(int id, CancellationToken cancellationToken);
		Task<List<AuctionPicRequestDto>> GetAuctionPicRequests(CancellationToken cancellationToken);
        Task<List<CustomerPicRequestDto>> GetCustomerPicRequests(CancellationToken cancellationToken);
        Task<bool> ConfirmCustomerPic(int id, CancellationToken cancellationToken);
        Task<bool> FaleCustomerPic(int id, CancellationToken cancellationToken);


    }
}
