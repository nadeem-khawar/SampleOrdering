using Microsoft.EntityFrameworkCore;
using SampleOrdering.OrderService.Domain.Orders;
using SampleOrdering.OrderService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleOrdering.OrderService.Domain.Shared.Orders;

namespace SampleOrdering.OrderService.EntityFrameworkCore.EntityFrameworkCore
{
    public class OrderServiceDbContext : AbpDbContext<OrderServiceDbContext>, IOrderServiceDbContext
    {
        public OrderServiceDbContext(DbContextOptions<OrderServiceDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ConfigureOrderService();

            modelBuilder.Entity<Order>(b =>
            {
                b.ToTable(OrderServiceDbProperties.DbTablePrefix + "Orders", OrderServiceDbProperties.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props

                
                b.Property(q => q.OrderDate).IsRequired();
                b.Property(q => q.OrderNumber).IsRequired();

                b.OwnsOne(o => o.Address, a => { a.WithOwner(); });
                b.OwnsOne(o => o.Buyer, a => { a.WithOwner(); });

                b.Navigation(q => q.OrderItems).UsePropertyAccessMode(PropertyAccessMode.Property);

                b.Property(q => q.OrderStatus).HasConversion(p => p.Value, p => OrderStatus.FromValue(p)).IsRequired();
                b.Property(q => q.PaymentMethod).HasConversion(p => p.Value, p => PaymentMethod.FromValue(p)).IsRequired();
            });
            modelBuilder.Entity<OrderItem>(b =>
            {
                b.ToTable(OrderServiceDbProperties.DbTablePrefix + "OrderItems",OrderServiceDbProperties.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props

                b.Property<Guid>("OrderId").IsRequired();
                b.Property(q => q.ProductId).IsRequired();
                b.Property(q => q.ProductName).HasMaxLength(200).IsRequired();
                b.Property(q => q.Quantity).IsRequired();
                b.Property(q => q.Price).IsRequired();
                b.Property(q => q.TotalPrice).IsRequired();
            });
        }

    }
}
