using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Values;
using Volo.Abp;

namespace SampleOrdering.OrderService.Domain.Orders
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        private Address()
        {
        }
        public Address(string street, string city, string country, string zipCode)
        {
            Street = Check.NotNullOrEmpty(street, nameof(street));
            City = Check.NotNullOrEmpty(city, nameof(city));
            Country = Check.NotNullOrEmpty(country, nameof(country));
            ZipCode = Check.NotNullOrEmpty(zipCode, nameof(zipCode));
        }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return Country;
            yield return ZipCode;
        }
    }
}
