using eShopping.Catalog.Application.Products.Commands.Create;
using eShopping.Catalog.Application.Products.Commands.Delete;
using eShopping.Catalog.Application.Products.Commands.Update;
using eShopping.Catalog.Application.Products.Queries.Get;
using eShopping.Catalog.Core.Entities.ProductAggregate.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopping.Catalog.Api.Controllers
{
    public class ProductsController(IMediator mediator) : ApiController
    {
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProduct(string productId)
            => Ok(await mediator.Send(new GetProductByIdQuery(productId)));

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductFilter productFilter)
            => Ok(await mediator.Send(new GetAllProductsQuery(productFilter)));

        [HttpGet("brand/{brandName}")]
        public async Task<IActionResult> GetProductsByBrandName(string brandName)
            => Ok(await mediator.Send(new GetProductByBrandQuery(brandName)));

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand productCommand)
            => Ok(await mediator.Send(productCommand));

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(string productId, [FromBody] UpdateProductCommand productCommand)
            => Ok(await mediator.Send(productCommand));

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
            => Ok(await mediator.Send(new DeleteProductByIdCommand(productId)));
    }
}
