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
         int SellerId, string Name, int ShopAddressId, MainAddressOutputDto? ShopAddress,
         ICollection<BoothProductOutputDto> BoothsProducts, SellerOutputDto Seller
        );
    public record BoothInputDto(
        int Id, string Name, int? ShopAddressId
    );

    public record GeneralBoothDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CityName { get; set; }
        public string? Address { get; set; }
        public int PostalCode { get; set; }
        public long TotalSales { get; set; }
        public int BoothProductsCount { get; set; }
    }

    public record BoothModel
    {
        public int Id { get; set; }
        public string SellerName { get; set; }
        public string SellerFamily { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string SellerEmail { get; set; }
        public long TotalSales { get; set; }
        public int BoothProductsCount { get; set; }
        public List<GeneralAuctionDto> Auctions { get; set; }
    }
    #endregion

    #region BoothProduct
    public record BoothProductOutputDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int BoothId { get; set; }
        public List<PictureDto> Pictures { get; set; }
        public List<PictureDto> CustomerPictures { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public List<string> Buyers { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ProductAttrOutModel> Attributes { get; set; }
    }

    public record BoothProductInputDto(
        int Quantity, int BoothId, int ProductId
        );

    public record BoothProductModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
    }

    public record GeneralBoothProductDto
    {
        public int Id { get; set; }
        public string PicturePath { get; set; }
        public string PictureAlt { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
    }
    #endregion



    #region BoothProductsPrice
    public record BoothProductsPriceOutputDto(
        int Id, int BoothProductId, DateTime FromDate, DateTime? ToDate, long Price,
        BoothProductOutputDto BoothProduct
        );
    public record BoothProductsPriceInputDto(
        int BoothProductId, DateTime FromDate, DateTime? ToDate, long Price
    );
    public record ProductPriceDto
    {
        public DateTime FromDate { get; set; }
        public long Price { get; set; }
    }
    #endregion



    #region Comment
    public record CommentOutputDto(
        int Id, byte Satisfaction, string Description, GeneralStatus Status, int BoothProductId,
        BoothProductOutputDto BoothProduct, int CustomerId, CustomerOutputDto Customer
        );

    public record CommentDto
    {
        public string CustomerName { get; set; }
        public string Description { get; set; }
        public byte Satisfaction { get; set; }
    }

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
        public GeneralStatus Status { get; set; } = GeneralStatus.AwaitConfirmation;
    };
    #endregion
}