using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.DTOs.Product;
using CleanArchitectureTemplate.Application.Features.ProductManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.Domain;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = CleanArchitectureTemplate.Application.Exceptions.ValidationException;

namespace CleanArchitectureTemplate.Application.Features.ProductManagement.Handlers.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<ProductDTO> _validator;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository, IValidator<ProductDTO> validator, IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var validationResult = await _validator.ValidateAsync(request.ProductDTO);

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Message = "Product creation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var product = _mapper.Map<Product>(request.ProductDTO);

            product = await _productRepository.Add(product);

            response.IsSuccessful = true;
            response.Message = "Product creation successful";
            response.Id = product.Id;

            return response;
        }
    }
}