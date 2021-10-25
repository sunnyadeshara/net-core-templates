using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductListDTO>>> Get()
        {
            var query = new GetProductListRequest();
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var query = new GetProductRequest { Id = id };
            var product = await _mediator.Send(query);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductDTO product)
        {
            var command = new CreateProductCommand { ProductDTO = product };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] ProductDTO product)
        {
            var command = new UpdateProductCommand { ProductDTO = product };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}