using System;
using Vita.Core.Domain.Repositories;

public class Goal : Entity
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public Guid CreatedBy { get; private set; }
    public DateTimeOffset CreatedOn { get; private set; }

    public Goal(string title, string description, Guid createdBy)
    {
        Id = Guid.NewGuid();
        CreatedOn = DateTimeOffset.UtcNow;

        Title = title ?? throw new ArgumentNullException(title);
        Description = description;

        if (createdBy == Guid.Empty)
            throw new ArgumentException(nameof(CreatedBy), "Invalid CreateById");

        CreatedBy = createdBy;
    }
}