using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Categories.Queries;
using Vita.Api.Application.Sql.Configuration;

namespace Vita.Api.Application.Sql.Categories
{
    public class GetCategoryByIdQueryHandler : IGetCategoryByIdQueryHandler
    {
        private const string sql = "Select Id, Name, Color from Categories where Id = @Id";
        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetCategoryByIdQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<CategoryDto>(sql, new { request.Id });
        }
    }
}
