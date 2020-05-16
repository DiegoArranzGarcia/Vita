using System;

namespace Vita.Domain.Abstrations.Entities
{

    public abstract class Entity
    {
        public Guid Id { get; set; }

        public bool IsTransient()
        {
            return Id == default;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || IsTransient())
                return false;

            return item.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() ^ 31;
        }
    }
}
