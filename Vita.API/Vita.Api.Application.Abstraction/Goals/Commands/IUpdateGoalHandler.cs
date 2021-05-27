using MediatR;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public interface IUpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, bool>
    {
    }
}
