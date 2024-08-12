using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;
namespace SampleOrdering.OrderService.Domain.Shared.Orders
{

    [EventName("EShopOnAbp.Order.Placed")]
    public class OrderPlacedEto : EtoBase
    {
        public Guid OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
