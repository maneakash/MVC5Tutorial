using FluentValidation;
using WebAPIFundamental.Models;

namespace WebAPIFundamental.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {

        public AddressValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.LastName).NotNull().NotEmpty();
            RuleFor(x => x.Country).NotNull().NotEmpty();
            RuleFor(x => x.State).NotNull().NotEmpty();
            RuleFor(x => x.City).NotNull().NotEmpty();
            RuleFor(x => x.Zip).NotNull().NotEmpty();
        }
    }
}