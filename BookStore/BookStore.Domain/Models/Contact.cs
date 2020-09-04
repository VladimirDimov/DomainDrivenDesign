using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Models
{
    public class Contact : ValueObject
    {
        public Contact()
        {
            PhoneNumbers = new HashSet<PhoneNumber>();
            Email = default!;
        }

        public ICollection<PhoneNumber> PhoneNumbers { get; private set; }

        public string Email { get; private set; }

        public Contact WithEmail(string email)
        {
            ValidateEmail(email);
            Email = email;

            return this;
        }

        public Contact WithPhoneNumbers(IEnumerable<PhoneNumber> phoneNumbers)
        {
            ValidatePhoneNumbers(phoneNumbers);
            PhoneNumbers = phoneNumbers.ToHashSet();

            return this;
        }

        private void ValidatePhoneNumbers(IEnumerable<PhoneNumber> phoneNumbers)
        {
            Guard.AgainstNull<InvalidContactException, IEnumerable<PhoneNumber>>(phoneNumbers, nameof(PhoneNumbers));
            foreach (var phoneNumber in phoneNumbers)
            {
                Guard.AgainstNull<InvalidContactException, PhoneNumber>(phoneNumber, "Phone Number");
            }
        }

        private void ValidateEmail(string email)
        {
            Guard.AgainstNull<InvalidContactException, string>(email, nameof(Email));
            Guard.ForStringLength<InvalidContactException>(email, 3, 50, nameof(Email));
        }
    }
}
