using eShopping.Catalog.Application.Types.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Catalog.Api.Controllers
{
    public class ProductTypesController(IMediator mediator) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllProductTypes()
            => Ok(await mediator.Send(new GetAllProductTypesQuery()));
    }
}
