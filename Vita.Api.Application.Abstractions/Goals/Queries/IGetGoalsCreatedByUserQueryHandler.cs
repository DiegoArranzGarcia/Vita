using MediatR;
using Vita.Api.Application.Goals.Queries;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Abstractions.Goals.Queries
{
    public interface IGetGoalsCreatedByUserQueryHandler : IRequestHandler<GetGoalsCreatedByUserQuery, PagedList<GoalDto>>
    {
    }
}
