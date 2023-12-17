﻿using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
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
        private readonly DateTime[] Views;
        private readonly IViewLogRepository _viewLogRepository;
        private int i;
        public ViewLogService(IConfiguration configuration, IViewLogRepository viewLogRepository)
        {
            Views = new DateTime[int.Parse(configuration["ViewLog:CountToInsert"])];
            _viewLogRepository = viewLogRepository;
        }


        public async Task<int> GetViewsCountInThisWeek()
            => await _viewLogRepository.GetCountByDay(7);
        

        public async Task AddView()
        {
            Views[i] = DateTime.Now;
            if (i == Views.Length-1)
            {
                await _viewLogRepository.AddRange(Views);
                i = 0;
            }
            else { i++; }
        }

    }
}
