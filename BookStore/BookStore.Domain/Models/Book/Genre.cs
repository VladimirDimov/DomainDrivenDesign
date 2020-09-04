using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Models.Book
{
    public class Genre : Entity<int>
    {
        internal Genre(string name)
        {
            SetName(name);
        }

        public string Name { get; set; } = default!;

        private void SetName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private void ValidateName(string name)
        {
            Guard.AgainstNull<InvalidGenreException, string>(name, nameof(Name));
            Guard.ForStringLength<InvalidGenreException>(name, 2, 30, nameof(Name));
        }
    }
}
