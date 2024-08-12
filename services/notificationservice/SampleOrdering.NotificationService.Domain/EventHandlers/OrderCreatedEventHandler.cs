using Microsoft.Extensions.Logging;
using SampleOrdering.OrderService.Domain.Shared.Orders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace SampleOrdering.NotificationService.Domain.EventHandlers
{
    public class OrderCreatedEventHandler : IDistributedEventHandler<OrderPlacedEto>, ITransientDependency
    {
        public async Task HandleEventAsync(OrderPlacedEto eventData)
        {
            Console.WriteLine("Order Placed Event Received: {0}", eventData.OrderDate);
        }
    }
}
