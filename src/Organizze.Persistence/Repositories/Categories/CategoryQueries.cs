namespace Organizze.Persistence.Repositories.Categories;

public static class CategoryQueries
{
    public const string Insert = @"
        INSERT INTO categories (""Id"", ""Name"")
        VALUES (@Id, @Name);
    ";

    public const string GetByName = @"
        SELECT
            ""Id"",
            ""Name""
        FROM categories
        WHERE ""Name"" = @Name
    ";

    public const string GetAllCategories = @"
        SELECT 
            ""Id"",
            ""Name""
        FROM categories
    ";
}