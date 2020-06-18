using MediatR;
using System;

namespace Vita.Api.Application.Goals.Commands
{
    public class CreateGoalCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
