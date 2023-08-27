using Dapper;
using Organizze.Domain.Entities.Tags;
using Organizze.Domain.Repositories.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Persistence.Repositories.Tags
{
    
    public class TagRepository : ITagRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tag?> GetByName(string name)
        {
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TagData>(
                TagQueries.GetByName, new { name });

            if (result != null)
                return Tag.Reconstitute(result);

            return null;
        }

        public async Task Insert(Tag tag)
        {
            await _unitOfWork.Connection.ExecuteAsync(
                TagQueries.Insert, new { Id = tag.Id, Name = tag.Name });
        }
    }
}
