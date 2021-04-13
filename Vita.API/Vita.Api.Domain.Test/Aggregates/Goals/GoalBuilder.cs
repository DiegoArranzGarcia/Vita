using System;
using System.Collections.Generic;
using System.Text;
using Vita.Api.Domain.Aggregates.Goals;

namespace Vita.Api.Domain.Test.Aggregates.Goals
{
    public class GoalBuilder
    {
        private string Title { get; set; } = "Default Title";
        private string Description { get; set; } = "Default Description";
        private Guid CreatedBy { get; set; } = Guid.NewGuid();


        public Goal Create()
        {
            return new Goal(Title, Description, CreatedBy);
        }

        public GoalBuilder WithCreatedBy(Guid createdBy)
        {
            CreatedBy = createdBy;
            return this;
        }

        public GoalBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public GoalBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }
    }
}
