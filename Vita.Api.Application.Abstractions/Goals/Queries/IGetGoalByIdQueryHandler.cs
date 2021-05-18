using MediatR;
using Vita.Api.Application.Goals.Queries;

namespace Vita.Api.Application.Abstractions.Goals.Queries
{
    public interface IGetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, GoalDto>
    {
    }
}
