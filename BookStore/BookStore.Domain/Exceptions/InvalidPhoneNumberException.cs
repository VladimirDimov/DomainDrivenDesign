namespace BookStore.Domain.Exceptions
{
    public class InvalidPhoneNumberException : BaseDomainException
    {
        public InvalidPhoneNumberException(string? message)
            : base(message)
        {
        }
    }
}
