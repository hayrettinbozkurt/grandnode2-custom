using FluentValidation;
using Grand.Infrastructure.Validators;
using Grand.Module.Api.DTOs.Order;

namespace Grand.Module.Api.Validators.Order
{
    public class ShipmentAddressValidator : BaseGrandValidator<ShipmentAddressDto>
    {
        public ShipmentAddressValidator(IEnumerable<IValidatorConsumer<ShipmentAddressDto>> validators) : base(validators)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Address1).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.District).NotEmpty();
            RuleFor(x => x.PostalCode).NotEmpty();
            RuleFor(x => x.CountryCode).NotEmpty();
            RuleFor(x => x.FullAddress).NotEmpty();
        }
    }
}