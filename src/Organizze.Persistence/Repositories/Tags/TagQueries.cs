using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Persistence.Repositories.Tags
{
    public class TagQueries
    {
        public const string Insert = @"
            INSERT INTO tags (""Id"", ""Name"")
            VALUES (@Id, @Name);
        ";

        public const string GetByName = @"
            SELECT
                ""Id"",
                ""Name""
            FROM tags
            WHERE ""Name"" = @Name
        ";
    }
}
