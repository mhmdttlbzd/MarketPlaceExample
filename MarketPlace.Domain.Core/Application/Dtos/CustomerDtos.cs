using MarketPlace.Domain.Core.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Dtos
{
    #region Customer
    public record CustomerOutputDto(
        int Id, ICollection<AuctionProposalOutputDto> ActionProposals, int AddressId, MainAddressOutputDto Address,
         ICollection<CommentOutputDto> Comments, ICollection<OrderOutputDto> Orders
        );
    public record CustomerInputDto(int AddressId);
    #endregion
}
