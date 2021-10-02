using CleanArchitectureTemplate.Application.DTOs.Category;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Queries
{
    public class GetCategoryRequest : IRequest<CategoryDTO>
    {
        public int Id { get; set; }
    }
}
