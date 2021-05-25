using MediatR;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public interface ICompleteGoalCommandHandler : IRequestHandler<CompleteGoalCommand, bool>
    {

    }
}
