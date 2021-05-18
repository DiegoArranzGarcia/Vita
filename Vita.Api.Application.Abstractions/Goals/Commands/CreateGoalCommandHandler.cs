using MediatR;
using System;
using Vita.Api.Application.Goals.Commands;

namespace Vita.Api.Application.Abstractions.Goals.Commands
{
    public interface ICreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, Guid>
    {
    }
}
