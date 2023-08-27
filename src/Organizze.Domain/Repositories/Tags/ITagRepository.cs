using Organizze.Domain.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Domain.Repositories.Tags
{
    public interface ITagRepository
    {
        Task<Tag?> GetByName(string name);
        Task Insert(Tag tag);
    }
}
