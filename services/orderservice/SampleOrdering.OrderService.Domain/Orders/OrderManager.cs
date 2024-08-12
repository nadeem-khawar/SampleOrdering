using SampleOrdering.OrderService.Domain.Shared.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.EventBus.Distributed;

namespace SampleOrdering.OrderService.Domain.Orders
{
    public class OrderManager : DomainService
    {
        private readonly IRepository<Order, Guid> _orderRepository;
        private readonly IDistributedEventBus _distributedEventBus;
        public OrderManager(IRepository<Order, Guid> orderRepository, IDistributedEventBus distributedEventBus)
        {
            _orderRepository = orderRepository;
            _distributedEventBus = distributedEventBus;
        }
        public async Task<Order> CreateOrderAsync(string paymentMethod, string buyerPhone, string buyerName, string buyerEmail,
            List<(Guid productId, string productName, int quantity, decimal price)> orderItems,
            string addressStreet,
            string addressCity,
            string addressCountry,
            string addressZipCode,
            Guid? buyerId
        )
        {
            // Create new order
            Order order = new Order(
                id: GuidGenerator.Create(),
                orderNumber: Guid.NewGuid().ToString(),
                buyer: new Buyer(buyerId, buyerName, buyerEmail, buyerName, buyerPhone),
                address: new Address(street: addressStreet,
                    city: addressCity,
                    country: addressCountry,
                    zipCode: addressZipCode),
                paymentMethod: PaymentMethod.FromName(paymentMethod.Trim(),ignoreCase:true)
            );

            // Add new order items
            foreach (var orderItem in orderItems)
            {
                order.AddOrderItem(
                    id: GuidGenerator.Create(),
                    productId: orderItem.productId,
                    productName: orderItem.productName,
                    quantity: orderItem.quantity,
                    price: orderItem.price
                );
            }
            var placedOrder = await _orderRepository.InsertAsync(order, true);


            //Publish Order placed event
            try
            {
                await _distributedEventBus.PublishAsync(new OrderPlacedEto
                {
                    OrderId = placedOrder.Id,
                    OrderDate = placedOrder.OrderDate,
                    OrderNo = placedOrder.OrderNumber
                });
            }
            catch   (Exception ex)
            {
                Console.WriteLine(ex.Message);                //Log error
            }
            
            

            return placedOrder;


        }
    }
}
