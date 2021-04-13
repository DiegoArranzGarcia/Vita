using System;
using Vita.Api.Domain.Aggregates.Dates;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Domain.Aggregates.Goals
{
    public class Goal : Entity
    {
        public string Description { get; set; }
        public DateTimeInterval AimDate { get; set; }
        public GoalStatus GoalStatus { get; private set; }
        public Guid CreatedBy { get; init; }
        public DateTimeOffset CreatedOn { get; init; }

        private string _title;
        private int _goalStatusId;

        public Goal(string title, string description, Guid createdBy, DateTimeInterval aimDate = null) : this(title, description, createdBy)
        {
            AimDate = aimDate;
        }

        /// <summary>
        /// EF constructor
        /// </summary>
        private Goal(string title, string description, Guid createdBy)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreatedBy = createdBy;
            CreatedOn = DateTimeOffset.UtcNow;
            _goalStatusId = GoalStatus.ToDo.Id;
        }

        public void Complete()
        {
            if (_goalStatusId == GoalStatus.ToDo.Id)
                _goalStatusId = GoalStatus.Completed.Id;
        }

        public string Title
        {
            get => _title;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException(nameof(Title));

                _title = value ?? throw new ArgumentNullException(nameof(Title));
            }
        }
    }
}