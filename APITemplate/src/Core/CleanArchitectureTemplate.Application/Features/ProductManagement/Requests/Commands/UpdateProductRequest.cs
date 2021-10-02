using CleanArchitectureTemplate.Application.DTOs.Product;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands
{
    public class UpdateProductRequest : IRequest<Unit>
    {
        public ProductDTO ProductDTO { get; set; }
    }
}
