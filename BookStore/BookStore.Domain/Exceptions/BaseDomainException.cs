using System;
using System.Runtime.Serialization;

namespace BookStore.Domain.Exceptions
{
    [Serializable]
    public class BaseDomainException : Exception
    {
        public BaseDomainException()
        {
        }

        public BaseDomainException(string? message)
            : base(message)
        {
        }

        public BaseDomainException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        protected BaseDomainException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
