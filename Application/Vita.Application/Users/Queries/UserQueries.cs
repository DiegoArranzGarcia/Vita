using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Vita.Application.Users.Queries
{
    public class UserQueries : IUserQueries
    {
        private readonly string _connectionString;

        public UserQueries(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<UserDto> GetUserByIdAsync(Guid userId)
        {
            string sql = "Select Id, Name, Email from Users where Id = @UserId;";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<UserDto>(sql, new { UserId = userId });
        }
    }
}
