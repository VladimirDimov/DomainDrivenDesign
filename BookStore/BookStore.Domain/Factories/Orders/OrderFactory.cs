using BookStore.Domain.Exceptions;
using BookStore.Domain.Models;
using BookStore.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Domain.Factories.Orders
{
    public class OrderFactory : IOrderFactory
    {
        private int orderNumber;
        private DateTime orderDate;
        private Contact orderContact = default!;
        private IEnumerable<OrderItem> orderItems = default!;
        private Payment orderPayment = default!;
        private Address orderToAddress = default!;
        private Money transportTax = default!;

        private IDictionary<string, bool> fieldSetFlags = new Dictionary<string, bool>
        {
            { nameof(orderNumber), false },
            { nameof(orderDate), false },
            { nameof(orderContact), false },
            { nameof(orderItems), false },
            { nameof(orderPayment), false },
            { nameof(orderToAddress), false },
            { nameof(transportTax), false },
        };

        public OrderFactory WithOrderNumber(int orderNumber)
        {
            this.orderNumber = orderNumber;
            this.fieldSetFlags[nameof(orderNumber)] = true;

            return this;
        }

        public OrderFactory WithOrderDate(DateTime orderDate)
        {
            this.orderDate = orderDate;
            this.SetFieldFlag(nameof(this.orderDate));

            return this;
        }

        public OrderFactory WithOrderContact(Contact orderContact)
        {
            this.orderContact = orderContact;
            this.SetFieldFlag(nameof(this.orderContact));

            return this;
        }

        public OrderFactory WithOrderItems(IEnumerable<OrderItem> orderItems)
        {
            this.orderItems = orderItems.ToHashSet();
            this.SetFieldFlag(nameof(this.orderItems));

            return this;
        }

        public OrderFactory WithOrderAddress(Address orderToAddress)
        {
            this.orderToAddress = orderToAddress;
            this.SetFieldFlag(nameof(this.orderToAddress));

            return this;
        }

        public OrderFactory WithOrderPayment(Payment orderPayment)
        {
            this.orderPayment = orderPayment;
            this.SetFieldFlag(nameof(this.orderPayment));

            return this;
        }

        public OrderFactory WithTransportTax(Money tax)
        {
            this.transportTax = tax;
            this.SetFieldFlag(nameof(this.transportTax));

            return this;
        }

        public Order Build()
        {
            ValidateMissingFields();

            return new Order(this.orderNumber, this.orderDate)
                .WithContact(this.orderContact)
                .WithOrderItems(this.orderItems)
                .WithPayment(this.orderPayment)
                .WithToAddress(this.orderToAddress)
                .WithTransportTax(this.transportTax);
        }

        private void ValidateMissingFields()
        {
            var unsetFields = fieldSetFlags.Where(x => !x.Value);
            if (unsetFields.Any())
                throw new AggregateException(
                    unsetFields.Select(field => new InvalidBookSeriesException($"{field.Key} must be provided")));
        }

        private void SetFieldFlag(string fieldName)
        {
            this.fieldSetFlags[fieldName] = true;
        }
    }
}
