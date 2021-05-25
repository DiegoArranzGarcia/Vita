using MediatR;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public interface IDeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, bool>
    {
    }
}
