using BookStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Bookstore.Domain.UnitTests
{
    public class ValueObjectTests
    {
        [Theory]
        [InlineData(Currency.BGN, 10, Currency.BGN, 10, true)]
        [InlineData(Currency.BGN, 0, Currency.BGN, 0, true)]
        [InlineData(Currency.BGN, 10, Currency.BGN, 20, false)]
        [InlineData(Currency.BGN, 10, Currency.EUR, 10, false)]
        public void ShouldCompareCorrectlyTrue(
            Currency leftCurreny,
            decimal leftAmount,
            Currency rightCurrency,
            decimal rightAmount,
            bool result)
        {
            var left = new Money(leftCurreny, leftAmount);
            var right = new Money(rightCurrency, rightAmount);

            Assert.Equal(result, left == right);
        }

        [Fact]
        public void ValueTypesAreInsertedCorrectlyIntoHashset()
        {
            var hashset = new HashSet<Money>();
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                var money = new Money((Currency)rnd.Next(1, 3), rnd.Next(1, 51));
                hashset.Add(money);
            }

            var check = hashset
                .Select(x => $"{x.Currency.ToString()}___{x.Amount}")
                .ToHashSet();

            Trace.WriteLine(hashset.Count);

            Assert.Equal(check.Count, hashset.Count);
        }
    }
}
