using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BookStore.Domain.Models.Books
{
    public class Book : IAggregateRoot
    {
        internal Book(string title, Language language)
        {
            SetTitle(title);
            SetLanguage(language);
        }

        public string Title { get; private set; } = default!;

        public int? Pages { get; private set; }

        public Publisher Publisher { get; private set; } = default!;

        public Money Price { get; private set; } = default!;

        internal Book WithAuthors(IEnumerable<Author> bookAuthors)
        {
            // TODO: validate
            Authors = bookAuthors.ToHashSet();

            return this;
        }

        public Language Language { get; private set; } = default!;

        public ICollection<Author> Authors { get; private set; } = new HashSet<Author>();

        public ICollection<Genre> Genres { get; private set; } = new HashSet<Genre>();

        public Book WithGenres(IEnumerable<Genre> genres)
        {
            Genres = genres.ToHashSet();

            return this;
        }

        public void SetTitle(string title)
        {
            ValidateTitle(title);
            Title = title;
        }

        public Book WithPages(int pages)
        {
            ValidatePages(pages);
            Pages = pages;

            return this;
        }

        public Book AddAuthor(Author author)
        {
            ValidateAuthor(author);
            Authors.Add(author);

            return this;
        }

        public Book WithPrice(Money price)
        {
            ValidatePrice(price);
            Price = price;

            return this;
        }

        public Book WithPublisher(Publisher publisher)
        {
            ValidatePublisher(publisher);
            Publisher = publisher;

            return this;
        }

        private static void ValidatePublisher(Publisher publisher)
        {
            Guard.AgainstNull<InvalidBookException, Publisher>(publisher, "Book's Publisher");
        }

        private void SetLanguage(Language language)
        {
            Guard.AgainstNull<InvalidBookException, Language>(language, nameof(Language));
            Language = language;
        }

        private static void ValidateTitle(string title)
        {
            Guard.AgainstNullOrEmpty<InvalidBookException>(title, nameof(Title));
            Guard.ForStringLength<InvalidBookException>(title, 1, 200);
        }

        private void ValidatePrice(Money price)
        {
            Guard.AgainstNull<InvalidBookException, Money>(price, nameof(Price));
        }

        private static void ValidateAuthor(Author author)
        {
            Guard.AgainstNull<InvalidBookException, Author>(author, nameof(Author));
        }

        private void ValidatePages(int pages)
        {
            Guard.AgainstNegativeNumber<InvalidBookException>(pages);
        }
    }
}
