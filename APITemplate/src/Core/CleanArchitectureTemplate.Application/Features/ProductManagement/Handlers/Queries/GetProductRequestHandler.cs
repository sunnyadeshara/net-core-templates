using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Queries
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.Get(request.Id);

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
