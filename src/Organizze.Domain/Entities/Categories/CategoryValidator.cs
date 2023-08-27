using FluentValidation;

namespace Organizze.Domain.Entities.Categories;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(category => category.Name).NotEmpty();
        RuleFor(category => category.Name.Length).LessThanOrEqualTo(30);
    }
}