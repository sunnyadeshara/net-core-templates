using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Commands
{
    public class UpdateProductRequestHandler : IRequestHandler<DeleteProductRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.ProductDTO);

            product = await _productRepository.Update(product);

            return Unit.Value;
        }
    }
}
