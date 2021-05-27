using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public interface ICreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Guid>
    {
    }
}
