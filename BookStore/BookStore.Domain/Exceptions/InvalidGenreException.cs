namespace BookStore.Domain.Exceptions
{
    public class InvalidGenreException : BaseDomainException
    {
        public InvalidGenreException(string? message)
            : base(message)
        {
        }
    }
}
