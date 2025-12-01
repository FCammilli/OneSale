using MediatR;
using Microsoft.AspNetCore.Mvc;
using OneSale.Application.Orders.Commands.CreateOrders;

namespace OneSale.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = await _mediator.Send(command);
            return Ok(order);
        }
    }
}
