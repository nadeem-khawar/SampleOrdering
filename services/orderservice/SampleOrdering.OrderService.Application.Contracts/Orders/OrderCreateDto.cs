using FluentValidation;
using SampleOrdering.OrderService.Domain.Shared.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using Volo.Abp.Validation;
namespace SampleOrdering.OrderService.Application.Contracts.Orders
{
    public class OrderCreateDto
    {
        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public BuyerDto Buyer { get; set; }

        [Required]
        public OrderAddressDto Address { get; set; }

        [Required]
        public List<OrderItemCreateDto> Products { get; set; }
    }
    public class BuyerDto
    {
        public Guid? Id { get;  set; }
        [Required]
        public string Name { get;  set; }
        [Required]
        public string Surname { get;  set; }
        [Required]
        public string Email { get;  set; }
        [Required]
        public string Phone { get;  set; }
    }
    public class OrderAddressDto
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string ZipCode { get; set; }
    }
    public class OrderItemCreateDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
    }

    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        string[] paymentMethods = new List<string> { PaymentMethod.Cash.Name, PaymentMethod.CreditCard.Name, PaymentMethod.DebitCard.Name }.ToArray();
        public OrderCreateDtoValidator()
        {
            //TODO: Add message for each rule
            RuleFor(x => x.PaymentMethod).Must(x => paymentMethods.Contains(x)).WithMessage("Please only use: " + String.Join(", ", paymentMethods));

        }
    }
}
