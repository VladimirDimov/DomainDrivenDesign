using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Models
{
    public class PhoneNumber
    {
        internal PhoneNumber(PhoneNumberType type, string number)
        {
            SetPhoneNumberType(type);
            SetNumber(number);
        }

        public PhoneNumberType Type { get; private set; } = default!;

        public string Number { get; private set; } = default!;

        private void SetPhoneNumberType(PhoneNumberType type)
        {
            Type = type;
        }

        private void SetNumber(string number)
        {
            Guard.AgainstNull<InvalidPhoneNumberException, string>(number, nameof(PhoneNumber));
            Guard.ForStringLength<InvalidPhoneNumberException>(number, 3, 50, nameof(PhoneNumber));
        }
    }
}
