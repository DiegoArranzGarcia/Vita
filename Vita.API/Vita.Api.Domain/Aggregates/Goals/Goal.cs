using System;
using Vita.Core.Domain.Repositories;

public class Goal : Entity
{
    public DateTimeOffset CreatedOn { get; private set; }

    public Goal(string title, string description, Guid createdBy)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        CreatedBy = createdBy;
        CreatedOn = DateTimeOffset.UtcNow;
    }

    private string title;
    public string Title
    {
        get => title;
        set
        {
            if (value == string.Empty)
                throw new ArgumentException(nameof(Title));

            title = value ?? throw new ArgumentNullException(nameof(Title));
        }
    }

    private string description;
    public string Description
    {
        get => description;
        set => description = value;
    }

    private Guid createdBy;
    public Guid CreatedBy
    {
        get => createdBy;
        set
        {
            if (value == Guid.Empty)
                throw new ArgumentException(nameof(CreatedBy), "Invalid CreateById");

            createdBy = value;
        }
    }
}