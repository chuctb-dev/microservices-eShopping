using eShopping.Catalog.Application.Brands.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Catalog.Api.Controllers
{
    public class ProductBrandsController(IMediator mediator) : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
            => Ok(await mediator.Send(new GetAllBrandsQuery()));
    }
}
