using Microsoft.Extensions.DependencyInjection;
using Organizze.Application.UseCases.Categories;
using Organizze.Application.UseCases.Tags;

namespace Organizze.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection service)
    {
        service.AddScoped<ICreateCategoryHandler, CreateCategoryHandler>();
        service.AddScoped<IGetAllCategoriesHandler, GetAllCategoriesHandler>();
        service.AddScoped<ICreateTagHandler, CreateTagHandler>();

        return service;
    }
}