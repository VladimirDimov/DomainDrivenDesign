namespace BookStore.Domain.Exceptions
{
    public class InvalidContactException : BaseDomainException
    {
        public InvalidContactException(string? message)
            : base(message)
        {
        }
    }
}
