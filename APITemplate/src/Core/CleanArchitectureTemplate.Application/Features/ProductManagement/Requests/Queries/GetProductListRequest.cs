using CleanArchitectureTemplate.Application.DTOs.Product;
using MediatR;
using System.Collections.Generic;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Queries
{
    public class GetProductListRequest : IRequest<List<ProductListDTO>>
    {
    }
}
