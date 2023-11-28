using MarketPlace.Domain.Core.Application.Entities._Booth;
using MarketPlace.Domain.Core.Application.Entities._Picture;
using MarketPlace.Domain.Core.Application.Enums;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Picture
    public record PictureDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string? Alt { get; set; }
    }
    #endregion




    #region ProductCustomerPic
    public record ProductCustomerPicOutputDto(
        int Id, int PictureId, int BoothProductId, int CustomerId,GeneralStatus Status,
        BoothProduct BoothProduct, PictureDto Picture, CustomerOutputDto Customer
        );
    public record ProductCustomerPicInputDto(
        int PictureId, int BoothProductId, int CustomerId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
    );
    public record CustomerPicRequestDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
    }
    #endregion


    #region ActionPicture
    public record AuctionPictureOutputDto(
        int Id, int PictureId, int ActionId,GeneralStatus Status,
        AuctionOutputDto Action, PictureDto Picture
        );
    public record AuctionPictureInputDto(
        int PictureId, int AuctionId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
	public record AuctionPicRequestDto
	{
		public int Id { get; set; }
		public string Path { get; set; }
		public string ProductName { get; set; }
	}
	#endregion


	#region ProductSalerPic
	public record ProductSalerPicOutputDto(
        int Id, int PictureId, int BoothProductId,GeneralStatus Status,
        BoothProductOutputDto BoothProduct, PictureDto Picture
        );
    public record ProductSalerPicInputDto(
        int PictureId, int BoothProductId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
	public record SalerPicRequestDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string ProductName { get; set; }
    }
	#endregion
}
