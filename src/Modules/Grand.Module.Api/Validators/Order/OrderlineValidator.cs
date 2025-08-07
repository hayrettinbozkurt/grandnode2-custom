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
            .NotEmpty().WithMessage("SKU boş olamaz");

        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Adet 0'dan büyük olmalı");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.ProductName).NotEmpty();
        RuleFor(x => x.ProductCode).GreaterThan(0);
        RuleFor(x => x.CurrencyCode).NotEmpty();
        }
    }
}