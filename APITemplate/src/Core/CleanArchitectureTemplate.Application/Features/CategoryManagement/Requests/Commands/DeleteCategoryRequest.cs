using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands
{
    public class DeleteCategoryRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
