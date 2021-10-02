using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDTO);

            product = await _productRepository.Add(product);

            return product.Id;
        }
    }
}
