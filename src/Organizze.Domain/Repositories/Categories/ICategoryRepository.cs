using Organizze.Domain.Entities.Categories;

namespace Organizze.Domain.Repositories.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByName(string name);
    Task<IEnumerable<Category>> GetAllCategories();
    Task Insert(Category category);
}