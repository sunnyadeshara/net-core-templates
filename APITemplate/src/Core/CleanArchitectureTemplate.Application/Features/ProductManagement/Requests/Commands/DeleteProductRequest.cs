using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands
{
    public class DeleteProductRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
