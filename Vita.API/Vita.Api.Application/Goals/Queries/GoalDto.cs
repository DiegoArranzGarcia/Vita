using System;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Application.Goals.Queries
{
    public class GoalDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string Status { get; set; }
    }
}