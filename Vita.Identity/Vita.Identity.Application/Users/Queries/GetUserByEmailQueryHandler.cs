using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Identity.Application.Abstraction.Users.Queries;
using Vita.Identity.Application.Sql.Configuration;

namespace Vita.Identity.Application.Sql.Users.Queries
{
    public class GetUserByEmailQueryHandler : IGetUserByEmailQueryHandler
    {
        private const string sql = "Select Id, Email from Users where Email = @Email;";

        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetUserByEmailQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<UserDto>(sql, new { request.Email });
        }
    }
}
