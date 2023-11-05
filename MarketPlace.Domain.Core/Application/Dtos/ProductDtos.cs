using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Product
    public record ProductOutputDto(
        int Id, string Name, ICollection<ProductsCustomAttribute>? ProductsCustomAttributes,
        ICollection<AuctionOutputDto>? BoothProductsActions,ICollection<BoothProductOutputDto>? BoothsProducts, int CategoryId,
        CategoryDto? Category, GeneralStatus? Status
        );

    public record ProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryTitle { get; set; }
    };

    public record ProductInputDto(
        string Name, int CategoryId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
    #endregion

    #region Category
    public record CategoryDto(
        int Id, string Title, int? ParentId,
        ICollection<ProductOutputDto> Products);
    #endregion
}
