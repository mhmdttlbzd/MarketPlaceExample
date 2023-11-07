using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Contract
{
    public interface ISalerAppService
    {
		Task UpdateCustomer(GeneralSalerInputDto inputDto, CancellationToken cancellationToken);
		Task<GeneralSalerEditDto> GetById(int id, CancellationToken cancellationToken);

	}
}
