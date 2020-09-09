using Bookstore.Domain.UnitTests.Common;
using BookStore.Domain.Factories.Books;
using BookStore.Domain.Models;
using System;
using Xunit;

namespace Bookstore.Domain.UnitTests
{
    public class BookFactoryTests
    {
        private readonly IBookFactory bookFactory;

        public BookFactoryTests()
        {
            this.bookFactory = new BookFactory();
        }

        [Fact]
        public void CreateBookMustNotThrow()
        {
            var book = this.bookFactory
                .WithTitle("Test Book")
                .WithAuthors(TestDataProvider.GetAuthors(2))
                .WithLanguage(new Language("English", "EN"))
                .WithGenres(TestDataProvider.GetGenres(3))
                .Build();
        }

        [Fact]
        public void CreateBookMustThrowIfMissingTitle()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var book = this.bookFactory
                //.WithTitle("Test Book")
                .WithAuthors(TestDataProvider.GetAuthors(2))
                .WithLanguage(new Language("English", "EN"))
                .WithGenres(TestDataProvider.GetGenres(3))
                .Build();
            });
        }

        [Fact]
        public void CreateBookMustThrowIfMissingAuthors()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var book = this.bookFactory
                .WithTitle("Test Book")
                //.WithAuthors(TestDataProvider.GetAuthors(2))
                .WithLanguage(new Language("English", "EN"))
                .WithGenres(TestDataProvider.GetGenres(3))
                .Build();
            });
        }

        [Fact]
        public void CreateBookMustThrowIfMissingLanguage()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var book = this.bookFactory
                .WithTitle("Test Book")
                .WithAuthors(TestDataProvider.GetAuthors(2))
                //.WithLanguage(new Language("English", "EN"))
                .WithGenres(TestDataProvider.GetGenres(3))
                .Build();
            });
        }
    }
}
