using MarketPlace.Domain.Core.Application.Entities;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Picture
    public record PictureDto(
        int Id, string Path, string? Alt, ICollection<ProductCustomerPic> CustomersProductPices,
        ICollection<AuctionPicture> PicturesActions, ICollection<ProductSalerPic> SalersProductPics
        );
    #endregion


    #region ProductCustomerPic
    public record ProductCustomerPicOutputDto(
        int Id, int PictureId, int BoothProductId, int CustomerId,GeneralStatus Status,
        BoothProduct BoothProduct, PictureDto Picture, CustomerOutputDto Customer
        );
    public record ProductCustomerPicInputDto(
        int PictureId, int BoothProductId, int CustomerId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
    );
    #endregion


    #region ActionPicture
    public record AuctionPictureOutputDto(
        int Id, int PictureId, int ActionId,GeneralStatus Status,
        AuctionOutputDto Action, PictureDto Picture
        );
    public record AuctionPictureInputDto(
        int PictureId, int ActionId,GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
    #endregion 


    #region ProductSalerPic
    public record ProductSalerPicOutputDto(
        int Id, int PictureId, int BoothProductId,GeneralStatus Status,
        BoothProductOutputDto BoothProduct, PictureDto Picture
        );
    public record ProductSalerPicInputDto(
        int PictureId, int BoothProductId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
    #endregion
}
