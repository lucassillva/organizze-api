using Organizze.Domain.Entities.Categories;
using Organizze.Domain.Repositories.Categories;

namespace Organizze.Domain.Services;

public interface ICategoryService
{
    Task<Category> Create(string name);
    Task<IEnumerable<Category>> GetAllCategories();
}

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<Category> Create(string name)
    {
        try
        {
            if (await CategoryAlreadyExist(name))
                throw new Exception("Categoria já existente.");

            var category = Category.New(name);
            await _repository.Insert(category);

            return category;
        }
        catch (Exception e)
        {
            throw new Exception("Falha ao inserir a categoria.", e);
        }
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        try
        {
            return await _repository.GetAllCategories();
        }
        catch (Exception e)
        {
            throw new Exception("Falha ao retornar a categoria.", e);
        }
    }

    private async Task<bool> CategoryAlreadyExist(string name)
    {
        var category = await _repository.GetByName(name);
        return category != null;
    }

}