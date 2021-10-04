using CleanArchitectureTemplate.Application.Responses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands
{
    public class DeleteProductCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
