using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Core.Application.Contract.Services.Log
{
    public interface IViewLogService
    {
        Task<int> GetViewsCountInThisWeek();
        Task LogView();
    }    }
