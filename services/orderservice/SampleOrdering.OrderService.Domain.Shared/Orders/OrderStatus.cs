using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdering.OrderService.Domain.Shared.Orders
{
    public class OrderStatus : SmartEnum<OrderStatus>
    {
        public static readonly OrderStatus New = new OrderStatus(nameof(New).ToLower(), 1);
        public static readonly OrderStatus InProgress = new OrderStatus(nameof(InProgress).ToLower(), 2);
        public static readonly OrderStatus Completed = new OrderStatus(nameof(Completed).ToLower(), 3);
        public static readonly OrderStatus Canceled = new OrderStatus(nameof(Canceled).ToLower(), 4);

        private OrderStatus(string name, int value) : base(name, value)
        {
        }
    }
}
