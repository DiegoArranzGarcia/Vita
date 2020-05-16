using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Vita.Application.Categories.Queries
{
    public class CategoryQueries : ICategoryQueries
    {
        private readonly string _connectionString;

        public CategoryQueries(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategories()
        {
            string sql = "Select Id, Name, Color from Category";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QueryAsync<CategoryDto>(sql);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesCreatedByUser(Guid userId)
        {
            string sql = "Select Id, Name, Color from Category where CreateBy = @UserId";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QueryAsync<CategoryDto>(sql, new { UserId = userId });
        }
    }
}
