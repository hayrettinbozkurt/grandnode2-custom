using FluentValidation;
using Grand.Infrastructure.Validators;
using Grand.Module.Api.DTOs.Order;

namespace Grand.Module.Api.Validators.Order
{
    public class ShipmentAddressValidator : BaseGrandValidator<ShipmentAddressDto>
    {
        public ShipmentAddressValidator(IEnumerable<IValidatorConsumer<ShipmentAddressDto>> validators) : base(validators)
        {
            RuleFor(x => x.FirstName)
     .NotEmpty().WithMessage("First name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(x => x.Address1)
                .NotEmpty().WithMessage("Primary address is required.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("District is required.");

            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.");

            RuleFor(x => x.CountryCode)
                .NotEmpty().WithMessage("Country code is required.");

            RuleFor(x => x.FullAddress)
                .NotEmpty().WithMessage("Full address is required.");
        }
    }
}