using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Categories.Queries;
using Vita.Api.Application.Sql.Configuration;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Sql.Categories
{
    public class GetCategoriesCreatedByUserQueryHandler : IGetCategoriesCreatedByUserQueryHandler
    {
        private const string sql = "Select Id, Name, Color from Categories where CreatedBy = @UserId";
        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetCategoriesCreatedByUserQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<PagedList<CategoryDto>> Handle(GetCategoriesCreatedByUserQuery query, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return (await connection.QueryAsync<CategoryDto>(sql, new { UserId = query.CreatedBy })).ToPagedList(query.PageNumber, query.PageSize);
        }
    }
}
