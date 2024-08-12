using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SampleOrdering.UserService.Application.Contracts.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task<List<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserAsync(Guid id);
        Task<UserDto> CreateUserAsync(UserCreateDto userDto);
        Task<PagedResultDto<UserDto>> GetListPagedAsync(PagedResultRequestDto input);
    }
}
