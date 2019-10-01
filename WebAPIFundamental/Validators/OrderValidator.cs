using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Results;
using WebAPIFundamental.Models;

namespace WebAPIFundamental.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {

        public OrderValidator()
        {
            RuleFor(x => x.Status).NotNull().NotEmpty().WithMessage("Order status should not be null, either A,C,P,D");
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.TotalAmount).NotNull().NotEmpty().GreaterThan(50);
            RuleFor(x => x.AmountPayable).NotNull().NotEmpty();
            RuleFor(x => x.BillingAddress).NotNull().SetValidator(new AddressValidator()); // nested object validator
            RuleFor(x => x.ShippingAddress).NotNull().SetValidator(new AddressValidator());

            RuleForEach(x => x.OrderLines).NotNull().NotEmpty(); // for list we can apply same rule

            RuleFor(x => x.AmountPayable).LessThanOrEqualTo(p => p.TotalAmount);
        }

    }
}