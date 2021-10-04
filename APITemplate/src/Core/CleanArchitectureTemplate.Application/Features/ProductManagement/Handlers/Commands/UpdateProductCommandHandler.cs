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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, BaseCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductDTO> _validator;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IValidator<ProductDTO> validator, IMapper mapper)
        {
            _productRepository = productRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            BaseCommandResponse response = new BaseCommandResponse();
            var validationResult = await _validator.ValidateAsync(request.ProductDTO, options =>
            {
                options.IncludeRuleSets("UpdateProduct").IncludeRulesNotInRuleSet();
            });

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Message = "Product updation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var product = _mapper.Map<Product>(request.ProductDTO);

            product = await _productRepository.Update(product);

            response.IsSuccessful = true;
            response.Message = "Product updation successful";

            return response;
        }
    }
}
