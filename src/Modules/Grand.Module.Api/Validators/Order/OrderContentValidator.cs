using FluentValidation;
using Grand.Infrastructure.Validators;
using Grand.Module.Api.DTOs.Order;

namespace Grand.Module.Api.Validators.Order
{
    public class OrderContentValidator : BaseGrandValidator<OrderContentDto>
    {
        public OrderContentValidator(IEnumerable<IValidatorConsumer<OrderContentDto>> validators,
        IEnumerable<IValidatorConsumer<ShipmentAddressDto>> shipmentValidators,
        IEnumerable<IValidatorConsumer<OrderLineDto>> orderlineValidators
         ) : base(validators)
        {
            RuleFor(x => x.CustomerEmail)
     .NotEmpty().WithMessage("Customer email address is required.")
     .EmailAddress().WithMessage("A valid email address must be provided.");

            RuleFor(x => x.OrderNumber)
                .NotEmpty().WithMessage("Order number is required.");

            RuleFor(x => x.GrossAmount)
                .GreaterThan(0).WithMessage("Gross amount must be greater than 0.");

            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total price must be greater than 0.");

            RuleFor(x => x.CurrencyCode)
                .NotEmpty().WithMessage("Currency code is required.");

            RuleFor(x => x.ShipmentAddress)
                .SetValidator(new ShipmentAddressValidator(shipmentValidators))
                .WithMessage("Shipment address is invalid.");

            RuleForEach(x => x.Lines)
                .SetValidator(new OrderlineValidator(orderlineValidators))
                .WithMessage("Order line is invalid.");

        }
    }
}