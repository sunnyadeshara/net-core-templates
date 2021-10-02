using CleanArchitectureTemplate.Application.DTOs.Product;
using MediatR;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Queries
{
    public class GetProductRequest : IRequest<ProductDTO>
    {
        public int Id { get; set; }
    }
}
