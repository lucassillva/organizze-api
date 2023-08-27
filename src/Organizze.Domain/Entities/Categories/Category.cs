using Organizze.Domain.Repositories.Categories;

namespace Organizze.Domain.Entities.Categories;

public class Category
{
    public Guid Id { get; }
    public string Name { get; }
    private readonly CategoryValidator _validator;

    internal static Category New(string name)
    {
        var category = new Category(Guid.NewGuid(), name);
        category.Validate();
        return category;
    }

    public static Category Reconstitute(CategoryData category)
    {
        return new Category(category.Id, category.Name);
    }

    private Category(Guid id, string name)
    {
        Id = id; 
        Name = name;
        _validator = new CategoryValidator();
    }

    private void Validate()
    {
        var result = _validator.Validate(this);

        if (result.IsValid is false)
            throw new ArgumentException($"Invalid Category. Errors: {string.Join("; ", result.Errors)}");
    }
}