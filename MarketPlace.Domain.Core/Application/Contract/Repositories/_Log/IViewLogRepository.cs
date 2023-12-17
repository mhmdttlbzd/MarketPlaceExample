using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Repositories._Log
{
    public interface IViewLogRepository
    {
        Task AddRange(DateTime[] input);
        Task<int> GetCountByDay(int day);
    }
}
