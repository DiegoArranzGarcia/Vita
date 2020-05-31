using System;
using Vita.Core.Domain.Repositories;

namespace Vita.Domain.Aggregates.Categories
{
    public class Category : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Color { get; private set; }
        public Guid? CreatedBy { get; private set; }

        public Category(string name, string color, Guid? createdBy = null)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Color = color ?? throw new ArgumentNullException(nameof(color));
            CreatedBy = createdBy;
        }

        public void Rename(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void ChangeColor(string color)
        {
            Color = color ?? throw new ArgumentNullException(nameof(color));
        }
    }
}
