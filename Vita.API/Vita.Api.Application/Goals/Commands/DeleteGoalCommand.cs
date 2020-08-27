using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vita.Api.Application.Goals.Commands
{
    public class DeleteGoalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
