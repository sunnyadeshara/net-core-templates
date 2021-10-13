using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts.Persistence;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using CleanArchitectureTemplate.Application.Responses;
using CleanArchitectureTemplate.Domain;
using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class UpdateCommandRequestHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryDTO> _validator;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCommandRequestHandler(ICategoryRepository categoryRepository, IValidator<CategoryDTO> validator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validationResult = await _validator.ValidateAsync(request.CategoryDTO, options =>
            {
                options.IncludeRuleSets("UpdateCategory").IncludeRulesNotInRuleSet();
            });

            if (!validationResult.IsValid)
            {
                response.IsSuccessful = false;
                response.Message = "Category updation failed";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                return response;
            }

            var category = _mapper.Map<Category>(request.CategoryDTO);

            await _categoryRepository.Update(category);

            response.IsSuccessful = true;
            response.Message = "Category updation successful";

            return response;
        }
    }
}
