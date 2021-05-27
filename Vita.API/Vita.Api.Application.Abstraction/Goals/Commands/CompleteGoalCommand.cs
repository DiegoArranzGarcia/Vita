using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public class CompleteGoalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
