using Grand.Business.Core.Interfaces.Common.Security;
using Grand.Domain.Permissions;
using Grand.Module.Api.Commands.Models.Customers;
using Grand.Module.Api.Commands.Models.Order;
using Grand.Module.Api.DTOs.Customers;
using Grand.Module.Api.DTOs.Order;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Grand.Module.Api.Controllers
{ 
    public class OrderController : BaseApiController
    {

        private readonly IPermissionService _permissionService;
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator, IPermissionService permissionService)
        {
            _permissionService = permissionService;
            _mediator = mediator;
        }

        [EndpointDescription("Post Order")]
        [EndpointName("PostOrder")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
          [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(OrderCreatedResponseDto))]
        public async Task<IActionResult> Post([FromBody] OrderDto dto)
        {
           

            var orderId=await _mediator.Send(new CreateOrderCommand { Order = dto });

            return CreatedAtAction(nameof(Post), new OrderCreatedResponseDto { Message = "Order Created", OrderId = orderId });
        }

    }
}