using System;
using Vita.Core.Domain.Repositories;

public class Goal : Entity
{
    public Guid CreatedBy { get; private set; }
    public string Title { get; private set; }

    public Goal(string title, Guid createdBy)
    {
        Id = Guid.NewGuid();
        Title = title ?? throw new ArgumentNullException(title);
        if (createdBy == Guid.Empty)
            throw new ArgumentException(nameof(CreatedBy), "Invalid CreateById");

        CreatedBy = createdBy;
    }
}