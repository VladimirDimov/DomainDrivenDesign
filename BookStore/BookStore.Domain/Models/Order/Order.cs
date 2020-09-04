using BookStore.Domain.Common;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Models.Order
{
    class Order : Entity<int>
    {
        public Order(int orderNumber, DateTime orderDate)
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

        private Order SetItems(IEnumerable<OrderItem> items)
        {
            // TODO: validate
            Items = items;

            return this;
        }

        private Order SetTransportTax(Money moeny)
        {
            // TODO: validate
            TransportTax = moeny;

            return this;
        }

        private Order SetToAddress(Address toAddress)
        {
            // TODO: validate
            ToAddress = toAddress;

            return this;
        }

        private Order SetContact(Contact contact)
        {
            // TODO: validate
            Contact = contact;

            return this;
        }

        private Order SetPayment(Payment payment)
        {
            // TODO: validate
            Payment = payment;

            return this;
        }
    }
}
