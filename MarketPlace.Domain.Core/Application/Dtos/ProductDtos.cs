using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    public record ProductOutputDto(
        int Id, string Name, ICollection<ProductsCustomAttribute> ProductsCustomAttributes,
        ICollection<AuctionOutputDto> BoothProductsActions,ICollection<BoothProductOutputDto> BoothsProducts, int CategoryId,
        CategoryDto Category, GeneralStatus Status
        );
    public record ProductInputDto(
        string Name, int CategoryId, GeneralStatus Status = GeneralStatus.AwaitConfirmation
        );
}
