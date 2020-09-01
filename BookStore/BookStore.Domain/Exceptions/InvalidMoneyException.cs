namespace BookStore.Domain.Exceptions
{
    public class InvalidMoneyException : BaseDomainException
    {
        public InvalidMoneyException(string? message)
            : base(message)
        {
        }
    }
}
