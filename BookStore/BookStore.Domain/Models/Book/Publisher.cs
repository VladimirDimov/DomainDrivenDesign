using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Models.Book
{
    public class Publisher : Entity<int>
    {
        private const string PublisherNameField = "Publiher Name";

        internal Publisher(string name)
        {
            SetName(name);
        }

        public string Name { get; private set; } = default!;

        public string Description { get; private set; } = default!;

        public Publisher WithDescription(string description)
        {
            ValidateDescription(description);

            Description = description;

            return this;
        }

        private void SetName(string name)
        {
            ValidateName(name);
            Name = name;
        }

        private void ValidateName(string name)
        {
            Guard.AgainstNull<InvalidPublisherException, string>(name, PublisherNameField);
            Guard.ForStringLength<InvalidPublisherException>(Name, 1, 30, PublisherNameField);
        }

        private void ValidateDescription(string description)
        {
            Guard.AgainstNull<InvalidPublisherException, string>(description, PublisherNameField);
            Guard.ForStringLength<InvalidPublisherException>(Name, 1, 500, PublisherNameField);
        }
    }
}
