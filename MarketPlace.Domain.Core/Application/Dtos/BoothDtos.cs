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
         int SalerId, string Name, int ShopAddressId, MainAddressOutputDto? ShopAddress,
         ICollection<BoothProductOutputDto> BoothsProducts, SalerOutputDto Saler
        );
    public record BoothInputDto(
        int Id, string Name, int? ShopAddressId
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

    public record CommentRequestDto
    {
        public int Id;
        public string Description { get; set; }
        public string BoothName { get; set; }
        public int CustomerId { get; set; }
        public string ProductName { get; set; }
    }
    public record CommentInputDto 
    {
        public byte Satisfaction { get; set; }
        public string Description { get; set; }
        public int? CustomerId { get; set; }
        public int? BoothProductId { get; set; }
    };
    #endregion
}