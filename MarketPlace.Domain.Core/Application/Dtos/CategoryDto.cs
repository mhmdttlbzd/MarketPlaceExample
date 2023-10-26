using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    public record CategoryDto(
        int Id, string Title, int? ParentId, ICollection<AttributeTemlateDto> CustomAttributeTemlates,
        ICollection<ProductOutputDto> Products);
}
