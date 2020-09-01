namespace BookStore.Domain.Exceptions
{
    class InvalidBookSeriesException : BaseDomainException
    {
        public InvalidBookSeriesException(string? message)
            : base(message)
        {
        }
    }
}
