namespace BookStore.Domain.Exceptions
{
    public class InvalidAddressException : BaseDomainException
    {
        public InvalidAddressException(string? message)
            : base(message)
        {
        }
    }
}
