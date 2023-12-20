using Dapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using MarketPlace.Domain.Core.Application.Entities._log;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Log.Dapper
{
    public class ErrorLogRepository: IErrorLogRepository
    {
        private readonly string _connectionString;
        private readonly GeneralOpration _opration;
        public ErrorLogRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Log");
            _opration = new GeneralOpration(_connectionString);
        }

        public async Task AddRange(ErrorLog?[] input)
        {
            await _opration.CheckTable("ErrorLog", "ErrorCode INT,Properties NVARCHAR(max),LogTime Date");

            string query = "INSERT INTO ErrorLog (ErrorCode,Properties,LogTime) VALUES";
            var parameters = new DynamicParameters();

            for (int i = 0; i < input.Length ; i++)
            {
                if (input[i] != null)
                {
                    if (i > 0)
                    {
                        query += ",\n";
                    }
					query += $" (@ErrorCode{i},@Properties{i},@LogTime{i})";
					parameters.Add($"ErrorCode{i}", input[i].ErrorCode, dbType: DbType.Int32);
					parameters.Add($"Properties{i}", input[i].Properties, DbType.String);
					parameters.Add($"LogTime{i}", input[i].LogTime, DbType.Date);
				}

            }

            if (parameters.ParameterNames.Count() != 0)
            {
                using (SqlConnection c = new(_connectionString))
                {
                    await c.ExecuteAsync(query, parameters);
                }
            }
        }

        public async Task<int> GetCountByDay(int day)
        {
            await _opration.CheckTable("ErrorLog", "ErrorCode INT,Properties NVARCHAR(max),LogTime Date");

            var date = DateTime.Now - TimeSpan.FromDays(day);
            var query = $"SELECT COUNT(*) FROM ErrorLog WHERE LogTime > @d";
            var parameters = new DynamicParameters();
            parameters.Add("d", date, dbType: DbType.Date);
            using (SqlConnection c = new(_connectionString))
            {
                var result = await c.ExecuteScalarAsync<int>(query, parameters);
                return result;
            }
        }

        public async Task<List<ErrorLog>> GetAll()
        {
			await _opration.CheckTable("ErrorLog", "ErrorCode INT,Properties NVARCHAR(max),LogTime Date");

            var query = "SELECT * FROM ErrorLog";
            using (SqlConnection c = new(_connectionString))
            {
                var res = await c.QueryAsync<ErrorLog>(query);
                return res.OrderBy(l => l.LogTime).Reverse().ToList();
            }
		}
        public async Task<IEnumerable<ErrorLog>> GetByErrorCode(int errorCode)
        {
			await _opration.CheckTable("ErrorLog", "ErrorCode INT,Properties NVARCHAR(max),LogTime Date");

            var query = $"SELECT * FROM ErrorLog WHERE ErrorCode = {errorCode}";
            using (SqlConnection c = new(_connectionString))
            {
                var res = await c.QueryAsync<ErrorLog>(query);
                return res;
            }
		}

    }
}
