using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp;

namespace SampleOrdering.UserService.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private User()
        {
        }
        public User(Guid id, string name, string surname, string username, string password, string email, string phoneNumber)
        {
            Id = id;
            Name = Check.NotNullOrEmpty(name, nameof(name));
            Surname = Check.NotNullOrEmpty(surname, nameof(surname));
            Username = Check.NotNullOrEmpty(username, nameof(username));
            Password = Check.NotNullOrEmpty(password, nameof(password));
            Email = Check.NotNullOrEmpty(email, nameof(email));
            PhoneNumber = Check.NotNullOrEmpty(phoneNumber, nameof(phoneNumber));
        }
    }
}
