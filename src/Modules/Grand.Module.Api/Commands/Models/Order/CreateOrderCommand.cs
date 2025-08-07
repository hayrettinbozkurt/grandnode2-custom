using Grand.Module.Api.DTOs.Order;
using MediatR;

namespace Grand.Module.Api.Commands.Models.Order
{
    public class CreateOrderCommand:IRequest<string>
    {
        public OrderDto Order { get; set; }
    }
}