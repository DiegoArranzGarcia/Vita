using MediatR;
using System;

namespace Vita.Api.Application.Goals.Commands
{
    public class UpdateGoalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? AimDateStart { get; set; }
        public DateTimeOffset? AimDateEnd { get; set; }
    }
}
