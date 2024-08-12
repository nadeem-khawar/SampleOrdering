using Microsoft.EntityFrameworkCore;
using SampleOrdering.OrderService.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace SampleOrdering.OrderService.EntityFrameworkCore.EntityFrameworkCore
{
    public interface IOrderServiceDbContext : IEfCoreDbContext
    {
        DbSet<Order> Orders { get; }
    }
}
