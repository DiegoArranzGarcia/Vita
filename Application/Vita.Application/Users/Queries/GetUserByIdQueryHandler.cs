using Dapper;
using MediatR;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Application.Configuration;

namespace Vita.Application.Users.Queries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        private const string sql = "Select Id, Name, Email from Users where Id = @UserId;";

        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetUserByIdQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<UserDto>(sql, new { UserId = request.Id });
        }
    }
}
