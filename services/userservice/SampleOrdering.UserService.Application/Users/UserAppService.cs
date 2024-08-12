using SampleOrdering.UserService.Application.Contracts.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using SampleOrdering.UserService.Domain.Users;
using Volo.Abp.Domain.Repositories;
using System.Collections.Generic;
namespace SampleOrdering.UserService.Application.Users
{
    public class UserAppService : ApplicationService, IUserAppService
    {
        const string defaultSorting = nameof(User.Name);
        public readonly IRepository<User,Guid> _userRepository;
        public UserAppService(IRepository<User, Guid> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto userDto)
        {
            //TODO: Check if user already exists

            User user = await _userRepository.InsertAsync(new User(Guid.NewGuid(), userDto.Name, userDto.Surname, userDto.Username, userDto.Password, userDto.Email, userDto.PhoneNumber));
            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<PagedResultDto<UserDto>> GetListPagedAsync(PagedResultRequestDto input)
        {
            List<User> users = await _userRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, defaultSorting);
            long totalCount = await _userRepository.GetCountAsync();
            List<UserDto> usersDto = MapUsers(users);
            return new PagedResultDto<UserDto>(totalCount, usersDto);
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            User user = await _userRepository.GetAsync(id);

            return ObjectMapper.Map<User, UserDto>(user);
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            List<User> users = await _userRepository.GetListAsync();
            List<UserDto> usersDto = MapUsers(users);
            return usersDto;

        }
        private List<UserDto> MapUsers(List<User> users)
        {
            List<UserDto> usersDto = new List<UserDto>();
            foreach (User user in users)
            {
                usersDto.Add(ObjectMapper.Map<User, UserDto>(user));
            }
            return usersDto;
        }
    }
}
