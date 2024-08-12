using SampleOrdering.OrderService.Domain.Shared.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp;

namespace SampleOrdering.OrderService.Domain.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public DateTime OrderDate { get; private set; }
        public string OrderNumber { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        public OrderStatus OrderStatus { get; private set; }

        public Buyer Buyer { get; private set; }
        public Address Address { get; private set; }

        public readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
        private Order()
        {
            _orderItems = new List<OrderItem>();
        }
        internal Order(Guid id, string orderNumber, PaymentMethod paymentMethod, Buyer buyer, Address address) : this()
        {
            Id = id;
            OrderDate = DateTime.UtcNow;
            OrderNumber = orderNumber;
            OrderStatus = OrderStatus.New;
            PaymentMethod = paymentMethod;
            Buyer = Check.NotNull(buyer, nameof(buyer));
            Address = Check.NotNull(address, nameof(address));
        }

        public Order AddOrderItem(Guid id, Guid productId, int quantity, decimal price, string productName)
        {
            var orderItem = new OrderItem(id, productId, quantity, price, productName);
            _orderItems.Add(orderItem);
            return this;
        }
        public decimal GetTotal()
        {
            return OrderItems.Sum(o => o.Quantity * o.Price);
        }
        public Order SetOrderCancelled()
        {
            OrderStatus = OrderStatus.Canceled;
            return this;
        }
        public Order SetOrderAsCompleted()
        {
            if (OrderStatus == OrderStatus.Canceled)
            {
                return this;
            }
            OrderStatus = OrderStatus.Completed;
            return this;
        }

    }
}
