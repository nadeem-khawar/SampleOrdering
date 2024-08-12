using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SampleOrdering.OrderService.Application.Contracts.Orders
{
    public interface IOrderApplicationService : IApplicationService
    {
        Task<List<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderAsync(Guid id);
        Task<OrderDto> CreateOrderAsync(OrderCreateDto userDto);
        Task<PagedResultDto<OrderDto>> GetListPagedAsync(PagedResultRequestDto input);
    }
}
