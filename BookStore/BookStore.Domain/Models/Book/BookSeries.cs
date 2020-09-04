using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Models.Book
{
    class BookSeries : Entity<int>
    {
        public BookSeries(string title)
        {
            SetTitle(title);
            Books = new HashSet<Book>();
        }

        public string Title { get; private set; } = default!;

        public Money Price { get; private set; } = default!;

        public ICollection<Book> Books { get; private set; }

        public int NumberOfBooks => Books.Count;

        public IEnumerable<Author> Authors => Books.SelectMany(b => b.Authors).ToHashSet();

        public BookSeries WithBooks(IEnumerable<Book> books)
        {
            Books = books.ToHashSet();

            return this;
        }

        public BookSeries AddBook(Book book)
        {
            ValidateBook(book);
            Books.Add(book);

            return this;
        }

        public BookSeries WithPrice(Money price)
        {
            ValidatePrice(price);
            Price = price;

            return this;
        }

        private void SetTitle(string title)
        {
            ValidateTitle(title);
            Title = title;
        }

        private void ValidateTitle(string title)
        {
            Guard.ForStringLength<InvalidBookSeriesException>(title, 1, 200, nameof(Title));
        }

        private static void ValidatePrice(Money price)
        {
            Guard.AgainstNull<InvalidBookSeriesException, Money>(price, "Price");
        }

        private static void ValidateBook(Book book)
        {
            Guard.AgainstNull<InvalidBookSeriesException, Book>(book, "Book");
        }
    }
}
