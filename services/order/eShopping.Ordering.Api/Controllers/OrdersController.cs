using eShopping.Ordering.Application.Orders.Commands.Delete;
using eShopping.Ordering.Application.Orders.Commands.Update;
using eShopping.Ordering.Application.Orders.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Ordering.Api.Controllers
{
    public class OrdersController(IMediator mediator) : ApiController
    {
        [HttpGet("username/{userName}")]
        public async Task<IActionResult> GetOrdersByUserName(string userName)
            => Ok(await mediator.Send(new GetOrderListQuery(userName)));

        [HttpPut]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateOrderCommand command)
            => Ok(await mediator.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(Guid id)
            => Ok(await mediator.Send(new DeleteOrderCommand(id)));
    }
}
