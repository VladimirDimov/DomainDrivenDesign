using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Models
{
    public class Money : ValueObject
    {
        public Money(Currency currency, decimal amount)
        {
            SetCurrency(currency);
            SetAmount(amount);
        }

        public Currency Currency { get; private set; }

        public decimal Amount { get; private set; }

        private void SetCurrency(Currency currency)
        {
            Currency = currency;
        }

        private void SetAmount(decimal amount)
        {
            ValidateAmount(amount);
            Amount = amount;
        }

        private void ValidateAmount(decimal amount)
        {
            Guard.AgainstNegativeNumber<InvalidMoneyException>(amount, nameof(Amount));
        }
    }
}
