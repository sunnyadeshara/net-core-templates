using CleanArchitectureTemplate.Application.DTOs.Product;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands
{
    public class CreateProductRequest : IRequest<int>
    {
        public ProductDTO ProductDTO { get; set; }
    }
}
