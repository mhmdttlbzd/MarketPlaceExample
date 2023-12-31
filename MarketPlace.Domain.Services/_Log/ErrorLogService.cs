﻿using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using MarketPlace.Domain.Core.Application.Contract.Services.Log;
using MarketPlace.Domain.Core.Application.Entities._log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Domain.Services._Log
{
    public class ErrorLogService : IErrorLogService
    {
        private ErrorLog[] Errors;
        private readonly IErrorLogRepository _errorLogRepository;
        private int i;
        public ErrorLogService(IConfiguration configuration, IErrorLogRepository errorLogRepository)
        {
            Errors = new ErrorLog[int.Parse(configuration["ErrorLog:CountToInsert"])];
            _errorLogRepository = errorLogRepository;
        }


        public async Task<int> GetErrorsCountInThisWeek()
        {
            await Save();
            return await _errorLogRepository.GetCountByDay(7);
        }

        public async Task LogError(Dictionary<string,string> properties,int errorCode)
        {
            Errors[i] = new ErrorLog(errorCode,properties);
            if (i == Errors.Length - 1)
            {
                await Save();
            }
            else { i++; }
        }

        public async Task Save()
        {
			await _errorLogRepository.AddRange(Errors);
            Errors = new ErrorLog?[Errors.Length];
			i = 0;
		}
		public async Task<IEnumerable<ErrorLog>> GetByErrorCode(int errorCode)
        {
            await Save();
            return await _errorLogRepository.GetByErrorCode(errorCode);
        }
		public async Task<IEnumerable<ErrorLog>> GetAll()
        {
            await Save();
            return await _errorLogRepository.GetAll();
        }
	}
}
