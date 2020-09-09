using Bookstore.Domain.UnitTests.Common;
using BookStore.Domain.Factories.Orders;
using BookStore.Domain.Models.Order;
using System;
using Xunit;

namespace Bookstore.Domain.UnitTests
{
    public class OrderFactoryTests
    {
        private readonly IOrderFactory orderFactory;

        public OrderFactoryTests()
        {
            this.orderFactory = new OrderFactory();
        }

        [Fact]
        public void CreateOrderMustNotThrow()
        {
            var order = this.orderFactory
                .WithOrderNumber(12345)
                .WithOrderDate(DateTime.Now)
                .WithOrderItems(TestDataProvider.GetOrderItems(5))
                .WithOrderContact(TestDataProvider.GetContact())
                .WithOrderPayment(TestDataProvider.GetPayment())
                .WithOrderAddress(TestDataProvider.GetAddress())
                .WithTransportTax(TestDataProvider.GetMoney(5, 50))
                .Build();
        }

        [Fact]
        public void CreateOrderShouldCreatePropertBooks()
        {
            var order = this.orderFactory
                .WithOrderNumber(12345)
                .WithOrderDate(DateTime.Now)
                .WithOrderItems(TestDataProvider.GetOrderItems(5))
                .WithOrderContact(TestDataProvider.GetContact())
                .WithOrderPayment(TestDataProvider.GetPayment())
                .WithOrderAddress(TestDataProvider.GetAddress())
                .WithTransportTax(TestDataProvider.GetMoney(5, 50))
                .Build();

            Assert.NotEqual(0, order.OrderNumber);
            Assert.NotEqual(default!, order.OrderDate);
            Assert.NotNull(order.Items);
            Assert.NotNull(order.Contact);
            Assert.NotNull(order.Payment);
            Assert.NotNull(order.ToAddress);
            Assert.NotNull(order.TransportTax);
        }

        [Fact]
        public void CreateOrderMustThrowIfNoOrderNumber()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var order = this.orderFactory
                //.WithOrderNumber(12345)
                .WithOrderDate(DateTime.Now)
                .WithOrderItems(TestDataProvider.GetOrderItems(5))
                .WithOrderContact(TestDataProvider.GetContact())
                .WithOrderPayment(TestDataProvider.GetPayment())
                .WithOrderAddress(TestDataProvider.GetAddress())
                .WithTransportTax(TestDataProvider.GetMoney(5, 50))
                .Build();
            });
        }

        [Fact]
        public void CreateOrderMustThrowIfNoOrderOrderDate()
        {
            Assert.Throws<AggregateException>(() =>
            {
                var order = this.orderFactory
                .WithOrderNumber(12345)
                //.WithOrderDate(DateTime.Now)
                .WithOrderItems(TestDataProvider.GetOrderItems(5))
                .WithOrderContact(TestDataProvider.GetContact())
                .WithOrderPayment(TestDataProvider.GetPayment())
                .WithOrderAddress(TestDataProvider.GetAddress())
                .WithTransportTax(TestDataProvider.GetMoney(5, 50))
                .Build();
            });
        }
    }
}
