using eShopping.Basket.Application.Baskets.Commands.Checkout;
using eShopping.Basket.Application.Baskets.Commands.Create;
using eShopping.Basket.Application.Baskets.Commands.Delete;
using eShopping.Basket.Application.Baskets.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Basket.Api.Controllers
{
    public class BasketsController(IMediator mediator) : ApiController
    {
        [HttpGet("{userName}")]
        public async Task<IActionResult> GetBasket(string username)
            => Ok(await mediator.Send(new GetBasketByUserNameQuery(username)));

        [HttpPost]
        public async Task<IActionResult> UpdateBasket([FromBody] CreateShoppingCartCommand createShoppingCartCommand)
            => Ok(await mediator.Send(createShoppingCartCommand));

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteBasket(string username)
            => Ok(await mediator.Send(new DeleteBasketByUsernameCommand(username)));

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckoutCommand basketCheckoutCommand)
            => Ok(await mediator.Send(basketCheckoutCommand));
    }
}
