using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;
using MarketPlace.Domain.Core.Application.Enums;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Product
    public record ProductOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<ProductAttrOutModel> attributes { get; set; }
        public GeneralStatus Status { get; set; }
    };

    public record ProductRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryTitle { get; set; }
    };

    public record ProductInputDto(
        string Name, int CategoryId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );

    public record ProductEditModel
    {

    }
    #endregion

    #region Category
    public record CategoryDto(
        int Id, string Title, int? ParentId,
        ICollection<ProductOutputDto> Products);
    #endregion
}
