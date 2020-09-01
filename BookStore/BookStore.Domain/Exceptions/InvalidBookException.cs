namespace BookStore.Domain.Exceptions
{
    class InvalidBookException : BaseDomainException
    {
        public InvalidBookException(string message)
            : base(message) { }
    }
}
