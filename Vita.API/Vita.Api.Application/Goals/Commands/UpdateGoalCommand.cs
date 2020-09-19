using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vita.Api.Application.Goals.Commands
{
    public class UpdateGoalCommand : IRequest<Goal>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
