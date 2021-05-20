using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Vita.Api.Application.Abstraction.Goals.Queries;
using Vita.Api.Application.Sql.Configuration;

namespace Vita.Api.Application.Sql.Goals.Queries
{
    public class GetGoalByIdQueryHandler : IGetGoalByIdQueryHandler
    {
        private const string sql = @"select g.Id, g.Title, g.Description, g.CreatedOn, g.AimDate_Start as AimDateStart, g.AimDate_End as AimDateEnd, gs.Name as Status
                                       from Goals g 
                                 inner join GoalStatus gs on g.GoalStatusId = gs.Id
                                      where g.Id = @Id";

        private readonly IConnectionStringProvider _connectionStringProvider;

        public GetGoalByIdQueryHandler(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
        }

        public async Task<GoalDto> Handle(GetGoalByIdQuery request, CancellationToken cancellationToken)
        {
            using var connection = new SqlConnection(_connectionStringProvider.ConnectionString);
            connection.Open();

            return await connection.QueryFirstOrDefaultAsync<GoalDto>(sql, new { request.Id });
        }
    }
}
