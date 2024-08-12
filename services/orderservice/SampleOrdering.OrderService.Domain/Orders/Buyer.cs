using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Values;

namespace SampleOrdering.OrderService.Domain.Orders
{
    public class Buyer : ValueObject
    {
        public Guid? Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        private Buyer()
        {
        }
        public Buyer(Guid? id,string name, string surname, string email, string phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Surname;
            yield return Email;
            yield return Phone;
        }
    }
}
