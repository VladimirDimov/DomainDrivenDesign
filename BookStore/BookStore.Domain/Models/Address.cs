using BookStore.Domain.Common;
using BookStore.Domain.Exceptions;

namespace BookStore.Domain.Models
{
    public class Address : ValueObject
    {
        public Address(string country, string city, string exactAddress)
        {
            Country = country;
            City = city;
            ExactAddress = exactAddress;

            PostalCode = default!;
        }

        public string Country { get; }
        public string City { get; }
        public string ExactAddress { get; }
        public string PostalCode { get; set; }

        public Address WithPostalCode(string postalCode)
        {
            Guard.ForStringLength<InvalidAddressException>(postalCode, 4, "Postal Code");
            PostalCode = postalCode;

            return this;
        }
    }
}
