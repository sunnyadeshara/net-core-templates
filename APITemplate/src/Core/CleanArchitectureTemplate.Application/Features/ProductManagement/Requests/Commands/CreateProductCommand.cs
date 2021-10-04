using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Responses;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands
{
    public class CreateProductCommand : IRequest<BaseCommandResponse>
    {
        public ProductDTO ProductDTO { get; set; }
    }
}
