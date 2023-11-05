using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities;
using MarketPlace.Domain.Core.Application.Entities._Picture;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Picture
{
    public interface IAuctionPictureRepo : IBaseCrudRepository<AuctionPicture, AuctionPictureInputDto, AuctionPictureOutputDto>
    {
		int GetRequestsCount();
		Task<List<AuctionPicRequestDto>> GetRequests(CancellationToken cancellationToken);
		Task FaleAsync(int id, CancellationToken cancellationToken);
		Task ConfirmAsync(int id, CancellationToken cancellationToken);
	}
}
