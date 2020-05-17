using Dapper;
using MediatR;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Application.Abstractions.Pagination;
using Vita.Application.Configuration;

namespace Vita.Application.Categories.Queries
{
    public class GetCategoriesCreatedByUserQueryHandler : IRequestHandler<GetCategoriesCreatedByUserQuery, PagedList<CategoryDto>>
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
