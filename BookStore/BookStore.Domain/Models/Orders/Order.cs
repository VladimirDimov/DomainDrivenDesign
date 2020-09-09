using BookStore.Domain.Common;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Models.Order
{
    public class Order : Entity<int>, IAggregateRoot
    {
        internal Order(int orderNumber, DateTime orderDate)
        {
            OrderNumber = orderNumber;
            OrderDate = orderDate;
        }

        public int OrderNumber { get; }

        public DateTime OrderDate { get; }

        public IEnumerable<OrderItem> Items { get; private set; } = new HashSet<OrderItem>();

        public Money TransportTax { get; private set; } = default!;

        public Address ToAddress { get; private set; } = default!;

        public Contact Contact { get; private set; } = default!;

        public Payment Payment { get; private set; } = default!;

        public Order WithOrderItems(IEnumerable<OrderItem> items)
        {
            // TODO: validate
            Items = items;

            return this;
        }

        public Order WithTransportTax(Money moeny)
        {
            // TODO: validate
            TransportTax = moeny;

            return this;
        }

        public Order WithToAddress(Address toAddress)
        {
            // TODO: validate
            ToAddress = toAddress;

            return this;
        }

        public Order WithContact(Contact contact)
        {
            // TODO: validate
            Contact = contact;

            return this;
        }

        public Order WithPayment(Payment payment)
        {
            // TODO: validate
            Payment = payment;

            return this;
        }
    }
}
