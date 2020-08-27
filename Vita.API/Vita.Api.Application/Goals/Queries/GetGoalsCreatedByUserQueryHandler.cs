using Dapper;
using MediatR;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Configuration;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Goals.Queries
{
    public class GetGoalsCreatedByUserQueryHandler : IRequestHandler<GetGoalsCreatedByUserQuery, PagedList<GoalDto>>
    {
        private const string sql = "Select Id, Title, Description, CreatedOn from Goals where CreatedBy = @UserId";
        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetGoalsCreatedByUserQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<PagedList<GoalDto>> Handle(GetGoalsCreatedByUserQuery query, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return (await connection.QueryAsync<GoalDto>(sql, new { UserId = query.CreatedBy })).ToPagedList(query.PageNumber, query.PageSize);
        }
    }
}
