using Organizze.Application.UseCases.Categories.Contracts;
using Organizze.Domain.Services;

namespace Organizze.Application.UseCases.Categories;

public interface ICreateCategoryHandler
{
    Task<CategoryResponse> Handle(CreateCategoryRequest request);
}

public class CreateCategoryHandler : ICreateCategoryHandler
{
    private readonly ICategoryService _service;

    public CreateCategoryHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<CategoryResponse> Handle(CreateCategoryRequest request)
    {
        var category = await _service.Create(request.Name);
        return new CategoryResponse(category);
    }
}