using Dapper;
using Organizze.Domain.Entities.Categories;
using Organizze.Domain.Repositories.Categories;
using System.Collections.Immutable;

namespace Organizze.Persistence.Repositories.Categories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Category?> GetByName(string name)
    {
        var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<CategoryData>(
            CategoryQueries.GetByName, new { Name = name });

        if (result != null)
            return Category.Reconstitute(result);

        return null;
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        var categories = await _unitOfWork.Connection.QueryAsync<CategoryData>(CategoryQueries.GetAllCategories);

        return categories.Select(category => Category.Reconstitute(category));
    }

    public async Task Insert(Category category)
    {
        await _unitOfWork.Connection.ExecuteAsync(
            CategoryQueries.Insert, new { Id = category.Id, Name = category.Name });
    }
}