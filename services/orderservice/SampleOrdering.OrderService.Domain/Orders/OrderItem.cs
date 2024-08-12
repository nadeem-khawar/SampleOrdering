using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp;
using JetBrains.Annotations;

namespace SampleOrdering.OrderService.Domain.Orders
{
    public class OrderItem : Entity<Guid>
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public decimal TotalPrice { get; private set; }
        protected OrderItem()
        {
        }
        public OrderItem(Guid id, Guid productId, int quantity, decimal price, [NotNull] string productName) : base(id)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            TotalPrice = Quantity * Price;
            productName = Check.NotNullOrEmpty(productName, nameof(productName));
        }
    }
}
