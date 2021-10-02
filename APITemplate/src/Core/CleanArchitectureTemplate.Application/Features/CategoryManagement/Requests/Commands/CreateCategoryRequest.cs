using CleanArchitectureTemplate.Application.DTOs.Category;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Handlers
{
    public class CreateCategoryRequest : IRequest<int>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}