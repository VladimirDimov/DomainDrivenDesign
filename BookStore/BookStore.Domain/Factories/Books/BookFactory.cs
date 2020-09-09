using BookStore.Domain.Exceptions;
using BookStore.Domain.Models;
using BookStore.Domain.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Factories.Books
{
    class BookFactory : IBookFactory
    {
        private string bookTitle = default!;
        private Language bookLanguage = default!;
        private IEnumerable<Author> bookAuthors = default!;
        private IEnumerable<Genre> bookGenres = default!;

        private IDictionary<string, bool> fieldSetFlags = new Dictionary<string, bool>
        {
            { nameof(bookTitle), false },
            { nameof(bookLanguage), false },
            { nameof(bookAuthors), false },
            { nameof(bookGenres), false },
        };

        public BookFactory WithTitle(string title)
        {
            this.bookTitle = title;
            this.fieldSetFlags[nameof(this.bookTitle)] = true;

            return this;
        }

        public BookFactory WithLanguage(Language bookLanguage)
        {
            this.bookLanguage = bookLanguage;
            this.fieldSetFlags[nameof(this.bookLanguage)] = true;

            return this;
        }

        public BookFactory WithAuthors(IEnumerable<Author> bookAuthors)
        {
            this.bookAuthors = bookAuthors;
            this.fieldSetFlags[nameof(this.bookAuthors)] = true;

            return this;
        }

        public BookFactory WithGenres(IEnumerable<Genre> bookGenres)
        {
            this.bookGenres = bookGenres;
            this.fieldSetFlags[nameof(this.bookGenres)] = true;

            return this;
        }

        public Book Build()
        {
            ValidateMissingFields();

            return new Book(this.bookTitle, this.bookLanguage)
                .WithAuthors(this.bookAuthors)
                .WithGenres(this.bookGenres)
                .WithAuthors(this.bookAuthors);
        }

        private void ValidateMissingFields()
        {
            var unsetFields = fieldSetFlags.Where(x => !x.Value);
            if (unsetFields.Any())
                throw new AggregateException(
                    unsetFields.Select(field => new InvalidBookException($"{field.Key} must be provided")));
        }
    }
}
