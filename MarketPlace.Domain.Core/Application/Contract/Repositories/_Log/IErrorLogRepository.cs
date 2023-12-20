using MarketPlace.Domain.Core.Application.Entities._log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Log
{
    public interface IErrorLogRepository : BaseLogRepositoryInterface<ErrorLog?>
    {
		Task<List<ErrorLog>> GetAll();
		Task<IEnumerable<ErrorLog>> GetByErrorCode(int errorCode);

	}
}
