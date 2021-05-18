using MediatR;
using System;
using Vita.Api.Domain.Aggregates.Dates;

namespace Vita.Api.Application.Goals.Commands
{
    public class CreateGoalCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTimeInterval AimDate { get; set; }
    }
}
