using SampleOrdering.OrderService.Application.Contracts.Orders;
using SampleOrdering.OrderService.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using Volo.Abp.Validation;

namespace SampleOrdering.OrderService.Application.Orders
{
    public class OrderAppService : ApplicationService, IOrderApplicationService, IValidationEnabled
    {
        private readonly IRepository<Order,Guid> _orderRepository;
        private readonly OrderManager _orderManager;
        public OrderAppService(IRepository<Order, Guid> orderRepository, OrderManager orderManager)
        {
            _orderRepository = orderRepository;
            _orderManager = orderManager;
        }
        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto orderDto)
        {
            var orderItems = GetProductListTuple(orderDto.Products);
            var placedOrder = await _orderManager.CreateOrderAsync
            (
                paymentMethod: orderDto.PaymentMethod,
                buyerName: orderDto.Buyer.Name,
                buyerEmail: orderDto.Buyer.Email,
                buyerPhone: orderDto.Buyer.Phone,
                buyerId: orderDto.Buyer.Id,
                orderItems: orderItems,
                addressStreet: orderDto.Address.Street,
                addressCity: orderDto.Address.City,
                addressCountry: orderDto.Address.Country,
                addressZipCode: orderDto.Address.ZipCode
            );
            
            return new OrderDto
            {
                Id = placedOrder.Id,
            };
        }
        public async Task<OrderDto> GetOrderAsync(Guid id)
        {
            var order = await _orderRepository.GetAsync(id);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }
        public async Task<List<OrderDto>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetListAsync();
            return ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);
        }
        public async Task<PagedResultDto<OrderDto>> GetListPagedAsync(PagedResultRequestDto input)
        {
            var orders = await _orderRepository.GetListAsync();
            var orderDtos = ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);
            return new PagedResultDto<OrderDto>(orderDtos.Count, orderDtos);
        }

        private List<(Guid productId, string productName, int quantity, decimal price)> GetProductListTuple(List<OrderItemCreateDto> products)
        {
            var orderItems =
                new List<(Guid productId, string productName, int quantity, decimal price)>();
            foreach (var product in products)
            {
                orderItems.Add((product.ProductId, product.ProductName, product.Quantity, product.Price));
            }

            return orderItems;
        }
    }
}
