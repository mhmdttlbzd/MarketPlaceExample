using MarketPlace.Domain.Core.Application.Entities;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Product
    public record ProductOutputDto(
        int Id, string Name, ICollection<ProductsCustomAttribute> ProductsCustomAttributes,
        ICollection<AuctionOutputDto> BoothProductsActions,ICollection<BoothProductOutputDto> BoothsProducts, int CategoryId,
        CategoryDto Category, GeneralStatus Status
        );
    public record ProductInputDto(
        string Name, int CategoryId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
    #endregion

    #region Category
    public record CategoryDto(
        int Id, string Title, int? ParentId, ICollection<AttributeTemplateDto> CustomAttributeTemlates,
        ICollection<ProductOutputDto> Products);
    #endregion
}
