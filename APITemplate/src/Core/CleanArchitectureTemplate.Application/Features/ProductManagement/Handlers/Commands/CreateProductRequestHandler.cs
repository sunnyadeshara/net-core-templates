using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Commands
{
    public class CreateProductRequestHandler : IRequestHandler<CreateProductRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDTO> _validator;
        private readonly IProductRepository _productRepository;

        public CreateProductRequestHandler(IProductRepository productRepository, IValidator<ProductDTO> validator, IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.ProductDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var product = _mapper.Map<Product>(request.ProductDTO);

            product = await _productRepository.Add(product);

            return product.Id;
        }
    }
}
