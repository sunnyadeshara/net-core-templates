using FluentValidation;

namespace CleanArchitectureTemplate.Application.DTOs.Category.Validators
{
    public class CategoryDTOValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDTOValidator()
        {
            RuleSet("UpdateCategory", () =>
            {
                RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("{PropertyName} is required.");
            });

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }
    }
}
