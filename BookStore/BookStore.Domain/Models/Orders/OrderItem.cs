using BookStore.Domain.Common;

namespace BookStore.Domain.Models.Order
{
    public class OrderItem : ValueObject
    {
        internal OrderItem(int bookId, int Amount)
        {
            this.BookId = bookId;
            this.Amount = Amount;
        }

        public int BookId { get; private set; }

        public int Amount { get; private set; }
    }
}
