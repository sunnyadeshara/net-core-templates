using CleanArchitectureTemplate.Application.Contracts;
using FluentValidation;

namespace CleanArchitectureTemplate.Application.DTOs.Product.Validators
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductDTOValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleSet("UpdateProduct", () =>
            {
                RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("{PropertyName} is required.");
            });

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0)
                .WithMessage("{PropertyName} is required.")
                .MustAsync(async (id, token) =>
                {
                    var categoryExists = await _categoryRepository.Exists(id);
                    return !categoryExists;
                }).WithMessage("{PropertyName} does not exist.");
        }
    }
}
