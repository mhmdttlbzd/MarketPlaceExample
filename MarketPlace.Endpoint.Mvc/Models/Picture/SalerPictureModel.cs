using MarketPlace.Domain.Core.Application.Dtos;

namespace MarketPlace.Endpoint.Mvc.Models.Picture
{
	public class SalerPictureRequestModel
	{
		public List<SalerPicRequestDto> InBooth { get; set; }
		public List<AuctionPicRequestDto> Auction { get; set; }
	}
}
