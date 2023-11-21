using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Contract
{
    public interface ISellerAppService
    {
		Task UpdateSeller(GeneralSellerInputDto inputDto, CancellationToken cancellationToken);
		Task<GeneralSellerEditDto> GetById(int id, CancellationToken cancellationToken);
        Task<GeneralSellerEditDto> GetByName(string userName, CancellationToken cancellationToken);

    }
}
