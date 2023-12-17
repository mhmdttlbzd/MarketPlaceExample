using Dapper;
using LiteDB;
using MarketPlace.Domain.Core.Application.Contract.Repositories._Log;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace MarketPlace.Infra.Data.Log.Dapper
{
    public class ViewLogRepository : IViewLogRepository
    {
        private IConfiguration _configuration;
        private readonly string _connectionString;

        public ViewLogRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("Log");
        }

        public async Task<int> GetCountByDay(int day)
        {
            await CheckTable("ViewLog");

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


        public async Task AddRange(DateTime[] input)
        {

            await CheckTable("ViewLog");

            string query = "INSERT INTO ViewLog (ViewTime) VALUES";
            var parameters = new DynamicParameters();

            for (int i = 0; i < input.Length-1; i++)
            {
                query += $" (@{i}),\n";
                parameters.Add($"{i}", input[i], dbType: DbType.Date);
            }
            query += $"(@{input.Length-1})";
            parameters.Add($"{input.Length - 1}", input[input.Length - 1], dbType: DbType.Date);


            using (SqlConnection c = new(_connectionString))
            {
                await c.ExecuteAsync(query, parameters);
            }
        }



        private async Task CheckTable(string tableName)
        {
            try
            {
                using (SqlConnection c = new(_connectionString))
                {
                    bool tableExist = await c.QueryFirstOrDefaultAsync<bool>(
                        $"SELECT 1 FROM sys.tables WHERE NAME = '{tableName}'"
                        );
                    if (!tableExist)
                    {
                        string creatCommand = $"CREATE TABLE {tableName} (Id INT IDENTITY(1,1) PRIMARY KEY, ViewTime DATE)";
                        await c.ExecuteAsync(creatCommand);
                    }
                }
            }
            catch (SqlException)
            {
                await CreateDatabase("MarketPlaceLogDb");
                await CheckTable(tableName);
            }
        }

        private async Task CreateDatabase(string databaseName)
        {
            using (SqlConnection c = new(_connectionString))
            {
                var builder = new SqlConnectionStringBuilder(_connectionString);

                builder.InitialCatalog = "master";
                using (var masterConnection = new SqlConnection(builder.ConnectionString))
                {
                    masterConnection.Open();
                    var createDatabaseCommand = $"CREATE DATABASE {databaseName}";
                    using (var command = new SqlCommand(createDatabaseCommand, masterConnection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }

            }
        }
    }
}
