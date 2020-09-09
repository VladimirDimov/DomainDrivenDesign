using BookStore.Domain.Models;
using BookStore.Domain.Models.Order;
using System;
using System.Collections.Generic;

namespace BookStore.Domain.Factories.Orders
{
    public interface IOrderFactory : IFactory<Order>
    {
        OrderFactory WithOrderAddress(Address orderToAddress);

        OrderFactory WithOrderContact(Contact orderContact);

        OrderFactory WithOrderPayment(Payment orderPayment);

        OrderFactory WithOrderItems(IEnumerable<OrderItem> orderItems);

        OrderFactory WithOrderDate(DateTime orderDate);

        OrderFactory WithOrderNumber(int orderNumber);
    }
}