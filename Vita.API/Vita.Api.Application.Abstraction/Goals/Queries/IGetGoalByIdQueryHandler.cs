using MediatR;

namespace Vita.Api.Application.Abstraction.Goals.Queries
{
    public interface IGetGoalByIdQueryHandler : IRequestHandler<GetGoalByIdQuery, GoalDto>
    {
    }
}
