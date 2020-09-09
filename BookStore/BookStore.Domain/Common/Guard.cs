using BookStore.Domain.Exceptions;
using System;
using System.Reflection.Metadata;

namespace BookStore.Domain.Common
{
    internal static class Guard
    {
        internal static void AgainstNullOrEmpty<TException>(string value, string name = "Value")
            where TException : BaseDomainException
        {
            if (string.IsNullOrEmpty(value))
            {
                ThrowException<TException>($"{name} cannot be null or empty.");
            }
        }

        internal static void AgainstPastDateTime<TException>(DateTime? date, string name = "DateTime")
            where TException : BaseDomainException
        {
            if (date == null) return;

            if (DateTime.UtcNow < date)
            {
                ThrowException<TException>($"{name} cannot be past date.");
            }
        }

        internal static void AgainstNegativeNumber<TException>(decimal? number, string name = "Number")
            where TException : BaseDomainException
        {
            if (number == null) return;

            if (number < 0)
            {
                ThrowException<TException>($"{name} cannot be less than zero.");
            }
        }

        internal static void AgainstNull<TException, TValue>(TValue value, string name = "Value")
            where TException : BaseDomainException
            where TValue : class
        {
            if (value == null) ThrowException<TException>($"{name} cannot be null");
        }

        internal static void ForStringLength<TException>(string value, int exactLength, string name = "value")
            where TException : BaseDomainException
        {
            if (value == null) return;
            if (value.Length != exactLength) ThrowException<TException>($"{name} length must be exactly {exactLength} characters");

        }

        internal static void ForMinStringLength<TException>(string value, int minLength, string name = "value")
            where TException : BaseDomainException
        {
            if (value == null) return;
            if (value.Length < minLength) ThrowException<TException>($"{name} length must be at least {minLength} characters");
        }

        internal static void ForMaxStringLength<TException>(string value, int maxLength, string name = "value")
            where TException : BaseDomainException
        {
            if (value == null) return;
            if (value.Length > maxLength) ThrowException<TException>($"{name} length must be at most {maxLength} characters");
        }

        internal static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "value")
            where TException : BaseDomainException
        {
            if (value == null) return;
            if (value.Length < minLength || maxLength < value.Length)
                ThrowException<TException>($"{name} length must be between {minLength} and {maxLength} characters");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException
        {
            var exception = Activator.CreateInstance(typeof(TException), message) as TException;

            if (exception != null) throw exception;
        }
    }
}
