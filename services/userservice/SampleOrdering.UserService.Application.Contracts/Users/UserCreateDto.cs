using FluentValidation;
using SampleOrdering.UserService.Domain.Shared.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleOrdering.UserService.Application.Contracts.Users
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }

    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            //TODO: Add message for each rule
            RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(UserConstants.MaxNameLength);
            RuleFor(x => x.Surname).NotEmpty().MinimumLength(2).MaximumLength(UserConstants.MaxSurnameLength);
            RuleFor(x => x.Username).NotEmpty().MinimumLength(6).MaximumLength(UserConstants.MaxUsernameLength);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).MaximumLength(UserConstants.MaxPasswordLength)
                    .Matches(@"[A-Z]+")
                    .Matches(@"[a-z]+")
                    .Matches(@"[0-9]+")
                    .Matches(@"[\!\?\*\.]+");
            RuleFor(x => x.Email).NotEmpty().MaximumLength(UserConstants.MaxEmailLength).EmailAddress();
            RuleFor(x => x.PhoneNumber).NotEmpty().MinimumLength(8).MaximumLength(UserConstants.MaxPhoneNumberLength);
        }
    }
}
