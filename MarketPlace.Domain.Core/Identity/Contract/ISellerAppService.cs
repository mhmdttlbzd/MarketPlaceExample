using MarketPlace.Domain.Core.Application.Dtos;
using MarketPlace.Domain.Core.Application.Entities._Saler;
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
        Task<GeneralSellerDto> GetGeneral(int id);
        Task<Seller> Create(GeneralSellerInputDto inputDto, CancellationToken cancellationToken);
        Task Register(GeneralSellerInputDto inputDto, CancellationToken cancellationToken);
    }
}
