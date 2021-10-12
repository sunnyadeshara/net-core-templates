using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryListDTO>>> Get()
        {
            var query = new GetCategoryListRequest();
            var categories = await _mediator.Send(query);
            return Ok(categories);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var query = new GetCategoryRequest { Id = id };
            var category = await _mediator.Send(query);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryDTO category)
        {
            var command = new CreateCategoryCommand { CategoryDTO = category };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] CategoryDTO category)
        {
            var command = new UpdateCategoryCommand { CategoryDTO = category };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCategoryCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
