using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdering.OrderService.Domain.Shared.Orders
{
    public class PaymentMethod : SmartEnum<PaymentMethod>
    {
        public static readonly PaymentMethod Cash = new PaymentMethod(nameof(Cash).ToLower(), 1);
        public static readonly PaymentMethod CreditCard = new PaymentMethod(nameof(CreditCard).ToLower(), 2);
        public static readonly PaymentMethod DebitCard = new PaymentMethod(nameof(DebitCard).ToLower(), 3);
        public PaymentMethod(string name, int value) : base(name, value)
        {
        }
    }
}
