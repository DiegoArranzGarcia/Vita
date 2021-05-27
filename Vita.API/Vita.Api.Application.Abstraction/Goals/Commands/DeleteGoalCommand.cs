using MediatR;
using System;

namespace Vita.Api.Application.Abstraction.Goals.Commands
{
    public class DeleteGoalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
