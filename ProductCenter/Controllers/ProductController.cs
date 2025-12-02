using Application.Dtos;
using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProductCenter.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {

        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var result = await _mediator.Send(new GetProductByIdQuery(UserId, productId));

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _mediator.Send(new GetProductsQuery());

            return Ok(result);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetProductsByUserId(int userId)
        {
            var result = await _mediator.Send(new GetProductsByUserIdQuery(userId));

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string productName)
        {
            await _mediator.Send(new CreateProductCommand(UserId, productName));

            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _mediator.Send(new DeleteProductCommand(UserId, productId));

            return Ok();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductDto productDto)
        {
            await _mediator.Send(new UpdateProductCommand(UserId, productId, productDto));

            return Ok();
        }

    }
}
