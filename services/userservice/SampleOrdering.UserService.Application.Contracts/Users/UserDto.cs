using SampleOrdering.UserService.Domain.Shared.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SampleOrdering.UserService.Application.Contracts.Users
{
    public class UserDto : EntityDto<Guid>
    {
        [Required]
        [MaxLength(UserConstants.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(UserConstants.MaxSurnameLength)]
        public string Surname { get; set; }
        [Required]
        [MaxLength(UserConstants.MaxUsernameLength)]
        public string Username { get; set; }
        [Required]
        [MaxLength(UserConstants.MaxPasswordLength)]
        public string Password { get; set; }
        [Required]
        [MaxLength(UserConstants.MaxEmailLength)]
        public string Email { get; set; }
        [Required]
        [MaxLength(UserConstants.MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }
    }
}
