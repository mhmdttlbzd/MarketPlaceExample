using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using MarketPlace.Domain.Core.Application.Contract.Services.Log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services.Log
{
    public class ViewLogService : IViewLogService
    {
        private DateTime?[] Views;
        private readonly IViewLogRepository _viewLogRepository;
        private int i;
        public ViewLogService(IConfiguration configuration, IViewLogRepository viewLogRepository)
        {
            Views = new DateTime?[int.Parse(configuration["ViewLog:CountToInsert"])];
            _viewLogRepository = viewLogRepository;
        }


        public async Task<int> GetViewsCountInThisWeek()
        {
            await Save();
			return await _viewLogRepository.GetCountByDay(7);
		}
            
        

        public async Task LogView()
        {
            Views[i] = DateTime.Now;
            if (i == Views.Length-1)
            {
                await Save();
            }
            else { i++; }
        }

        private async Task Save()
        {
			await _viewLogRepository.AddRange(Views);
            Views = new DateTime?[Views.Length];
            i = 0;
		}

    }
}
