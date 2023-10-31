using MarketPlace.Domain.Core.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Booth
    public record BoothOutputDto(
         int SalerId, string Name, int? ShopAddressId, MainAddressOutputDto? ShopAddress,
         ICollection<BoothProductOutputDto> BoothsProducts, SalerOutputDto Saler
        );
    public record BoothInputDto(
        int SalerId, string Name, int? ShopAddressId
    );
    #endregion

    #region BoothProduct
    public record BoothProductOutputDto(
        int Id, int Quantity, int BoothId, BoothOutputDto Booth, ICollection<BoothProductsPriceOutputDto> BoothProductsPrices,
        ICollection<CommentOutputDto> Comments, ICollection<ProductCustomerPicOutputDto> CustomersProductPices,
        ICollection<OrderLineOutputDto> OrderLines, int ProductId, ProductOutputDto Product, 
        ICollection<ProductSalerPicOutputDto> SalersProductPics
        );
    public record BoothProductInputDto(
        int Quantity, int BoothId, int ProductId
        );
    #endregion



    #region BoothProductsPrice
    public record BoothProductsPriceOutputDto(
        int Id, int BoothProductId, DateTime FromDate, DateTime? ToDate, long Price,
        BoothProductOutputDto BoothProduct
        );
    public record BoothProductsPriceInputDto(
        int BoothProductId, DateTime FromDate, DateTime? ToDate, long Price
    );
    #endregion



    #region Comment
    public record CommentOutputDto(
        int Id, byte Satisfaction, string Description, GeneralStatus Status, int BoothProductId,
        BoothProductOutputDto BoothProduct, int CustomerId, CustomerOutputDto Customer
        );
    public record CommentInputDto(
         byte Satisfaction, string Description, int BoothProductId, int CustomerId,
         GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
    #endregion
}