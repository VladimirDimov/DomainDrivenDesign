namespace BookStore.Domain.Exceptions
{
    public class InvalidPublisherException : BaseDomainException
    {
        public InvalidPublisherException(string? message)
            : base(message)
        {
        }
    }
}
