

namespace MarketPlace.Domain.Core.Application.Entities;

public class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<CustomAttributeTemplate> CustomAttributeTemlates { get; set; } = new List<CustomAttributeTemplate>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
