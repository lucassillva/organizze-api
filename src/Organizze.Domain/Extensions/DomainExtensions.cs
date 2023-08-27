using Microsoft.Extensions.DependencyInjection;
using Organizze.Domain.Services;

namespace Organizze.Domain.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainDependencies(this IServiceCollection service)
    {
        service.AddScoped<ICategoryService, CategoryService>();
        service.AddScoped<ITagService, TagService>();

        return service;
    }
}