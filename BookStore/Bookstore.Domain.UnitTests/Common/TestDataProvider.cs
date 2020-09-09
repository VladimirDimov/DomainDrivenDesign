using Bogus;
using Bogus.Extensions;
using BookStore.Domain.Models;
using BookStore.Domain.Models.Books;
using BookStore.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Domain.UnitTests.Common
{
    internal class TestDataProvider
    {
        private static Faker faker = new Faker("en");

        private static IEnumerable<Genre> genres;

        static TestDataProvider()
        {
            genres = new List<Genre>()
            {
                new Genre("Action"){ Id = 1 },
                new Genre("Drama"){ Id = 2 },
                new Genre("Thriller"){ Id = 3 },
                new Genre("Romance"){ Id = 4 },
            };
        }

        internal static Contact GetContact()
        {
            return new Contact()
                .WithEmail(GetEmail())
                .WithPhoneNumbers(GetPhoneNumber(2));
        }

        internal static Money GetMoney(int min, int max)
        {
            return new Money(faker.PickRandom<Currency>(), faker.Random.Decimal(min, max));
        }

        internal static Address GetAddress()
        {
            return new Address(faker.Address.Country(), faker.Address.City(), faker.Address.StreetAddress());
        }

        internal static Payment GetPayment()
        {
            return new Payment(faker.PickRandom<PaymentType>(), new Money(faker.PickRandom<Currency>(), faker.Random.Decimal(3, 200)));
        }

        internal static IEnumerable<PhoneNumber> GetPhoneNumber(int number)
        {
            return faker.Make(number, () => new PhoneNumber(faker.PickRandom<PhoneNumberType>(), faker.Phone.PhoneNumber()));
        }

        internal static IEnumerable<OrderItem> GetOrderItems(int number)
        {
            return Enumerable.Range(0, number)
                .Select(i => GetOrderItems());
        }

        internal static OrderItem GetOrderItems()
        {
            return new OrderItem(faker.Random.Int(1000, 1000000), faker.Random.Int(1, 5));
        }

        internal static IEnumerable<Author> GetAuthors(int number)
        {
            return Enumerable.Range(0, number).Select(i => GetAuthor());
        }

        internal static Author GetAuthor()
        {
            return new Faker<Author>()
                .CustomInstantiator(f => new Author(f.Name.FirstName(), f.Name.LastName()))
                .RuleFor(x => x.BirthDate, (f, u) => f.Date.Between(DateTime.Now.AddYears(-100), DateTime.Now.AddYears(-20)))
                .RuleFor(x => x.DieDate, (f, u) => f.Date.Between(u.BirthDate.Value, DateTime.Now).OrNull(f, 0.5f))
                .RuleFor(x => x.Information, (f, u) => f.Lorem.Random.Words());
        }

        internal static IEnumerable<Genre> GetGenres(int number)
        {
            return faker.PickRandom(genres, number);
        }

        internal static string GetEmail()
        {
            return faker.Internet.Email();
        }
    }
}
