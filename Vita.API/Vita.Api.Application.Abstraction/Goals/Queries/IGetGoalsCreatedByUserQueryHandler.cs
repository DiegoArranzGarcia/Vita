using MediatR;
using Vita.Api.Application.Goals.Queries;
using Vita.Core.Pagination;

namespace Vita.Api.Application.Abstraction.Goals.Queries
{
    public interface IGetGoalsCreatedByUserQueryHandler : IRequestHandler<GetGoalsCreatedByUserQuery, PagedList<GoalDto>>
    {
    }
}
