using System;
using Vita.Api.Domain.Aggregates.Goals;
using Vita.Core.Domain.Repositories;

public class Goal : Entity
{
    public string Description { get; set; }
    public GoalStatus GoalStatus { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }
    private string _title;
    private int _goalStatusId;
    private Guid _createdBy;    

    public Goal(string title, string description, Guid createdBy)
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

    public Guid CreatedBy
    {
        get => _createdBy;
        set
        {
            if (value == Guid.Empty)
                throw new ArgumentException(nameof(CreatedBy), "Invalid CreateById");

            _createdBy = value;
        }
    }
}