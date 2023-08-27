using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Organizze.Domain.Repositories.Categories;
using Organizze.Domain.Repositories.Tags;
using Organizze.Persistence.Migrations;
using Organizze.Persistence.Repositories.Categories;
using Organizze.Persistence.Repositories.Tags;

namespace Organizze.Persistence.Extensions;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistenceDependencies(
        this IServiceCollection service,
        IConfiguration configuration)
    {
        service.AddScoped<IUnitOfWork>(_ =>
        {
            var builder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Default"));
            var connection = new NpgsqlConnection(builder.ToString());
            return new UnitOfWork(connection);
        });

        service.AddScoped<ICategoryRepository, CategoryRepository>();
        service.AddScoped<ITagRepository, TagRepository>();

        return service;
    }

    public static void CreateDatabase(this IApplicationBuilder _, IConfiguration configuration)
    {
        var serviceProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(builder => builder
                .AddPostgres()
                .WithGlobalConnectionString(configuration.GetConnectionString("Default"))
                .ScanIn(typeof(Initial).Assembly).For.Migrations().For.EmbeddedResources())
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .BuildServiceProvider(false);

        using (serviceProvider.CreateScope())
        {
            serviceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
        }
    }
}