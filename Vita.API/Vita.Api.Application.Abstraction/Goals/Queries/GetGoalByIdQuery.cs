using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Goals.Queries
{
    public class GetGoalByIdQuery : IRequest<GoalDto>
    {
        public Guid Id { get; set; }
    }
}
