using FluentValidation;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Infrastructure.Validators;
using Grand.Module.Api.DTOs.Order;

namespace Grand.Module.Api.Validators.Order
{
    public class OrderValidator : BaseGrandValidator<OrderDto>
    {
        public OrderValidator(IEnumerable<IValidatorConsumer<OrderDto>> validators,
        IEnumerable<IValidatorConsumer<OrderContentDto>> orderContentValidators,
        IEnumerable<IValidatorConsumer<ShipmentAddressDto>> shipmentAddressValidators,
         IEnumerable<IValidatorConsumer<OrderLineDto>> orderLineValidators,
        ITranslationService translationService) : base(validators)
        {

            
                        RuleForEach(x => x.Content)
                       .SetValidator(x=>new OrderContentValidator(orderContentValidators,
                       shipmentAddressValidators,
                       orderLineValidators));
                       
 

        }
    }
}