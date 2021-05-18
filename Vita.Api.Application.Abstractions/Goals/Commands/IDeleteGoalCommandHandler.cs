using MediatR;
using Vita.Api.Application.Goals.Commands;

namespace Vita.Api.Application.Abstractions.Goals.Commands
{
    public interface IDeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand, bool>
    {
    }
}
