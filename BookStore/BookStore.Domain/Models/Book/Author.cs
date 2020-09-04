using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System;

namespace BookStore.Domain.Models.Book
{
    public class Author
    {
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            Information = default!;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Information { get; private set; }

        public DateTime? BirthDate { get; private set; }

        public DateTime? DieDate { get; private set; }

        public Author WithInformation(string information)
        {
            ValidateInformation(information);
            this.Information = information;

            return this;
        }

        public Author WithBirthDate(DateTime date)
        {
            ValidateBirthDate(date);
            this.BirthDate = date;

            return this;
        }

        public Author WithDieDate(DateTime date)
        {
            ValidateDieDate(date);
            this.DieDate = date;

            return this;
        }

        private void ValidateDieDate(DateTime date)
        {
            Guard.AgainstPastDateTime<InvalidAuthorException>(date);
        }

        private void ValidateBirthDate(DateTime date)
        {
            Guard.AgainstPastDateTime<InvalidAuthorException>(date);
        }

        private void ValidateInformation(string information)
        {
            Guard.AgainstNullOrEmpty<InvalidAuthorException>(information, "Author Information");
        }
    }
}
