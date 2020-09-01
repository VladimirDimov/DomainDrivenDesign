namespace BookStore.Domain.Exceptions
{
    public class InvalidAuthorException : BaseDomainException
    {
        public InvalidAuthorException(string message)
            : base(message) { }
    }
}
