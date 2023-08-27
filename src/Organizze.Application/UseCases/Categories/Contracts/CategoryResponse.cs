using Organizze.Domain.Entities.Categories;

namespace Organizze.Application.UseCases.Categories.Contracts;

public class CategoryResponse
{
    public Guid Id { get; }
    public string Name { get; }

    public CategoryResponse(Category category)
    {
        Id = category.Id;
        Name = category.Name;
    }
}