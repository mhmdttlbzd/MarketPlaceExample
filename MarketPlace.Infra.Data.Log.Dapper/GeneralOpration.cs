using Dapper;
using LiteDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Infra.Data.Log.Dapper
{
    internal class GeneralOpration
    {
        private readonly string _connectionString;

        public GeneralOpration(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task CheckTable(string tableName , string colomns)
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
                        string creatCommand = $"CREATE TABLE {tableName} (Id INT IDENTITY(1,1) PRIMARY KEY, {colomns})";
                        await c.ExecuteAsync(creatCommand);
                    }
                }
            }
            catch (SqlException)
            {
                await CreateDatabase("MarketPlaceLogDb");
                await CheckTable(tableName,colomns);
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
