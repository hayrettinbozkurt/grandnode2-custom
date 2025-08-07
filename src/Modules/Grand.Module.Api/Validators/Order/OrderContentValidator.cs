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
            RuleFor(x => x.CustomerEmail).NotEmpty().EmailAddress(); 
            RuleFor(x => x.OrderNumber).NotEmpty();
            RuleFor(x => x.GrossAmount).GreaterThan(0);
            RuleFor(x => x.TotalPrice).GreaterThan(0);
            RuleFor(x => x.CurrencyCode).NotEmpty(); 
            RuleFor(x => x.ShipmentAddress)
                .SetValidator(new ShipmentAddressValidator(shipmentValidators));

            RuleForEach(x => x.Lines)
                .SetValidator(new OrderlineValidator(orderlineValidators));
            
            
        }
    }
}