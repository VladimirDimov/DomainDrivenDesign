using BookStore.Domain.Models;
using BookStore.Domain.Models.Books;
using System.Collections.Generic;

namespace BookStore.Domain.Factories.Books
{
    interface IBookFactory : IFactory<Book>
    {
        BookFactory WithAuthors(IEnumerable<Author> bookAuthors);

        BookFactory WithGenres(IEnumerable<Genre> bookGenres);

        BookFactory WithLanguage(Language bookLanguage);

        BookFactory WithTitle(string title);
    }
}