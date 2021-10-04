using CleanArchitectureTemplate.Application.Responses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
