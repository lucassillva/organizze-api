using Microsoft.AspNetCore.Mvc;
using Organizze.Application.UseCases.Categories;
using Organizze.Application.UseCases.Categories.Contracts;

namespace Organizze.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICreateCategoryHandler _createCategoryHandler;
    private readonly IGetAllCategoriesHandler _getAllCategoriesHandler;

    public CategoryController(
        ICreateCategoryHandler createCategoryHandler, 
        IGetAllCategoriesHandler getAllCategoriesHandler)
    {
        _createCategoryHandler = createCategoryHandler;
        _getAllCategoriesHandler = getAllCategoriesHandler;
    }


    [HttpPost]
    [ProducesResponseType(typeof(CategoryResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return BadRequest();

        var response = await _createCategoryHandler.Handle(request);

        return StatusCode(StatusCodes.Status201Created, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<CategoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get()
    {
        var categories = await _getAllCategoriesHandler.Handle();

        return Ok(categories);
    }

}