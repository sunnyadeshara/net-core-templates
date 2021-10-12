using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Responses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CategoryDTO CategoryDTO { get; set; }
    }
}