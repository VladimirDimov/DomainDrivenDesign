using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System.Collections.Generic;

namespace BookStore.Domain.Models
{
    public partial class Book
    {
        public Book(string title, Language language)
        {
            SetTitle(title);
            SetLanguage(language);
        }

        public string Title { get; private set; } = default!;

        public int? Pages { get; private set; }

        public Money Price { get; private set; } = default!;

        public Language Language { get; private set; } = default!;

        public ICollection<Author> Authors { get; private set; } = new List<Author>();

        public ICollection<Genre> Genres { get; private set; } = new List<Genre>();

        public void SetTitle(string title)
        {
            ValidateTitle(title);
            Title = title;
        }

        public Book SetPages(int pages)
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
