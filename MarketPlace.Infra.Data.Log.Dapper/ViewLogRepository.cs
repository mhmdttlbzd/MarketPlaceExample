using Dapper;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MarketPlace.Infra.Data.Log.Dapper
{
    public class ViewLogRepository : IViewLogRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly GeneralOpration _opration;
        public ViewLogRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Log");
            _opration = new GeneralOpration(_connectionString);
        }

        public async Task<int> GetCountByDay(int day)
        {
            await _opration.CheckTable("ViewLog","ViewTime Date");

            var date = DateTime.Now - TimeSpan.FromDays(day);
            var query = $"SELECT COUNT(*) FROM ViewLog WHERE ViewTime > @d";
            var parameters = new DynamicParameters();
            parameters.Add("d", date, dbType: DbType.Date);
            using (SqlConnection c = new(_configuration.GetConnectionString("Log")))
            {
                var result = await c.ExecuteScalarAsync<int>(query,parameters);
                return result;
            }
        }


        public async Task AddRange(DateTime?[] input)
        {

            await _opration.CheckTable("ViewLog", "ViewTime Date");

            string query = "INSERT INTO ViewLog (ViewTime) VALUES";
            var parameters = new DynamicParameters();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != null)
                {
                    if (i != 0)
                    {
                        query += ",\n";
                    }
					query += $" (@{i})";
					parameters.Add($"{i}", input[i], dbType: DbType.Date);
				}

            }
            using (SqlConnection c = new(_connectionString))
            {
                await c.ExecuteAsync(query, parameters);
            }
        }

    }
}
