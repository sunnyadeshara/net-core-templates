using AutoMapper;
using CleanArchitectureTemplate.Application.Contracts;
using CleanArchitectureTemplate.Application.DTOs.Category;
using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Handlers;
using CleanArchitectureTemplate.Domain;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Handlers.Commands
{
    public class CreateCategoryRequestHandler : IRequestHandler<CreateCategoryRequest, int>
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryDTO> _validator;
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryRequestHandler(ICategoryRepository categoryRepository, IValidator<CategoryDTO> validator, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request.CategoryDTO);

            if (!validationResult.IsValid)
                throw new Exception();

            var category = _mapper.Map<Category>(request.CategoryDTO);

            category = await _categoryRepository.Add(category);

            return category.Id;
        }
    }
}
