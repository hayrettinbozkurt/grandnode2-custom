using FluentValidation;
using Grand.Infrastructure.Validators;
using Grand.Module.Api.DTOs.Order;

namespace Grand.Module.Api.Validators.Order
{
    public class OrderlineValidator : BaseGrandValidator<OrderLineDto>
    {
        public OrderlineValidator(IEnumerable<IValidatorConsumer<OrderLineDto>> validators) : base(validators)
        {
            RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("Product SKU cannot be empty.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price must be 0 or greater.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.ProductCode)
                .GreaterThan(0).WithMessage("Product code must be greater than 0.");

            RuleFor(x => x.CurrencyCode)
                .NotEmpty().WithMessage("Currency code is required.");
        }
    }
}