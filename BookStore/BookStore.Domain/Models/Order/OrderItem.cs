using BookStore.Domain.Common;

namespace BookStore.Domain.Models.Order
{
    internal class OrderItem : ValueObject
    {
        public int BookId { get; private set; }

        public int Amount { get; private set; }
    }
}
