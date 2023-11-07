using MarketPlace.Domain.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Identity.Contract
{
    public interface ICustomerAppService
    {
        Task UpdateCustomer(GeneralCustomerInputDto inputDto, CancellationToken cancellationToken);
        Task<GeneralCustomerEditDto> GetById(int id);

	}
}
