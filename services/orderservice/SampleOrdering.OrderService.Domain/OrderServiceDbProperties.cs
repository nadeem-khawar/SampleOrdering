using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdering.OrderService.Domain
{
    public class OrderServiceDbProperties
    {
        public static string DbTablePrefix { get; set; } = "";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "OrderService";
    }
}
