using Organizze.Application.UseCases.Categories.Contracts;
using Organizze.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Application.UseCases.Categories;

public interface IGetAllCategoriesHandler
{
    Task<IEnumerable<CategoryResponse>> Handle();
}

public class GetAllCategoriesHandler : IGetAllCategoriesHandler
{

    private readonly ICategoryService _service;

    public GetAllCategoriesHandler(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IEnumerable<CategoryResponse>> Handle()
    {
        var categories = await _service.GetAllCategories();

        return categories.Select(category => new CategoryResponse(category));
    }
}

