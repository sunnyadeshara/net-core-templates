using CleanArchitectureTemplate.Application.Features.CategoryManagement.Requests.Commands;
using FluentValidation;

namespace CleanArchitectureTemplate.Application.Features.CategoryManagement.Validations
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.CategoryDTO.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
        }
    }
}
