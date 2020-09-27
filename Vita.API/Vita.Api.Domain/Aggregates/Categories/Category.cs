using System;
using Vita.Core.Domain.Repositories;

namespace Vita.Api.Domain.Aggregates.Categories
{
    public class Category : Entity, IAggregateRoot
    {
        public Category(string name, string color, Guid createdBy)
        {
            Id = Guid.NewGuid();
            Name = name;
            Color = color;
            CreatedBy = createdBy;
        }

        private string name;
        public string Name 
        { 
            get => name;  
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException(nameof(Name));

                name = value ?? throw new ArgumentNullException(nameof(Name));
            }
        }

        private string color;
        public string Color
        {
            get => color;
            set
            {
                if (value == string.Empty)
                    throw new ArgumentException(nameof(Color));

                color = value ?? throw new ArgumentNullException(nameof(Color));
            }
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
}
