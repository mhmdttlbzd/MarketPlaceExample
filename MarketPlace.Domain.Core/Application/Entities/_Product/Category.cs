

using MarketPlace.Domain.Core.Application.Entities._CustomAttribute;

namespace MarketPlace.Domain.Core.Application.Entities._Prodoct;

public class Category
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual ICollection<CategoryCustomAttribute> CategoryCustomAttributes { get; set; } = new List<CategoryCustomAttribute>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
