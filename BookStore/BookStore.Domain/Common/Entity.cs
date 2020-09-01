using Microsoft.VisualBasic.CompilerServices;

namespace BookStore.Domain.Common
{
    public class Entity<TId>
         where TId : struct
    {
        public Entity()
        {
            Id = default!;
        }

        public TId Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (this.Id.Equals(default) || other.Id.Equals(default))
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return (this.GetType().FullName + this.Id).GetHashCode();
        }

        public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
        {
            if (first == null && second == null) return true;

            if (first is null || second is null) return false;

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TId>? first, Entity<TId>? second)
        {
            return !(first == second);
        }
    }
}
