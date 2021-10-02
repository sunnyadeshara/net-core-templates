using CleanArchitectureTemplate.Application.DTOs.Category;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands
{
    public class UpdateCategoryRequest : IRequest<Unit>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}
