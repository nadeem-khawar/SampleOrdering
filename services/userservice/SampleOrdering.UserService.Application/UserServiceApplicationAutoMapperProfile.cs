using AutoMapper;
using SampleOrdering.UserService.Application.Contracts.Users;
using SampleOrdering.UserService.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SampleOrdering.UserService.Application
{
    public class UserServiceApplicationAutoMapperProfile : Profile
    {
        public UserServiceApplicationAutoMapperProfile()
        {
            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserDto>();
        }
    }
}
