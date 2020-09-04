using BookStore.Domain.Common;

namespace BookStore.Domain.Models.Order
{
    public class Payment : Entity<int>
    {
        public Payment(PaymentType paymentType, Money amount)
        {
            PaymentType = paymentType;
            Amount = amount;
        }

        public PaymentType PaymentType { get; }

        public Money Amount { get; }
    }
}
