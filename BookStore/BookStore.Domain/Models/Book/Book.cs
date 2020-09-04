using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Models.Book
{
    public class Book
    {
        internal Book(string title, Language language)
        {
            WithTitle(title);
            SetLanguage(language);
        }

        public string Title { get; private set; } = default!;

        public int? Pages { get; private set; }

        public Publisher Publisher { get; private set; } = default!;

        public Money Price { get; private set; } = default!;

        public Language Language { get; private set; } = default!;

        public ICollection<Author> Authors { get; private set; } = new HashSet<Author>();

        public ICollection<Genre> Genres { get; private set; } = new HashSet<Genre>();

        public Book WithGenres(IEnumerable<Genre> genres)
        {
            Genres = genres.ToHashSet();

            return this;
        }

        public Book WithTitle(string title)
        {
            ValidateTitle(title);
            Title = title;

            return this;
        }

        public Book WithPages(int pages)
        {
            ValidatePages(pages);
            Pages = pages;

            return this;
        }

        public Book WithAuthors(IEnumerable<Author> authors)
        {
            Authors = authors.ToHashSet();

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
