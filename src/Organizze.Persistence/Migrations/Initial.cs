using FluentMigrator;

namespace Organizze.Persistence.Migrations;

[Migration(202305292229)]
public class Initial : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript($"{typeof(Initial).FullName}.sql");
    }

    public override void Down()
    {
    }
}