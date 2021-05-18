using Dapper;
using MediatR;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstractions.Goals.Queries;
using Vita.Api.Application.Configuration;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Goals.Queries
{
    public class GetGoalsCreatedByUserQueryHandler : IGetGoalsCreatedByUserQueryHandler
    {
        private const string sql = @"select g.Id, g.Title, g.Description, g.CreatedOn, g.AimDate_Start as AimDateStart, g.AimDate_End as AimDateEnd, gs.Name as Status
                                       from Goals g
                                 inner join GoalStatus gs on g.GoalStatusId = gs.Id
                                      where CreatedBy = @UserId";

        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetGoalsCreatedByUserQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<PagedList<GoalDto>> Handle(GetGoalsCreatedByUserQuery query, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            var sqlQuery = sql;

            if (query.StartDate.HasValue && query.EndDate.HasValue)
                sqlQuery += $@" and ((g.AimDate_Start is null and g.AimDate_End is null) or 
                                      (@Start <= g.AimDate_End and g.AimDate_Start <= @End))";

            return (await connection.QueryAsync<GoalDto>(sqlQuery, new { UserId = query.CreatedBy, Start = query.StartDate, End = query.EndDate })).ToPagedList(query.PageNumber, query.PageSize);
        }
    }
}
