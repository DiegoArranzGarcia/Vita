using MediatR;

namespace Vita.Api.Application.Goals.Commands
{
    public interface ICompleteGoalCommandHandler : IRequestHandler<CompleteGoalCommand, bool>
    {
       
    }
}
