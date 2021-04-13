using MediatR;
using System;
using Vita.Api.Domain.Aggregates.Dates;

namespace Vita.Api.Application.Goals.Commands
{
    public class UpdateGoalCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeInterval AimDate { get; set; }
    }
}
