namespace Organizze.Application.UseCases.Categories.Contracts;

public class CreateCategoryRequest
{
    public string Name { get; }

    public CreateCategoryRequest(string name)
    {
        Name = name;
    }
}