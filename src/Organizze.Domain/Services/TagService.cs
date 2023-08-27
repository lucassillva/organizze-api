using Organizze.Domain.Entities.Tags;
using Organizze.Domain.Repositories.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Domain.Services
{
    public interface ITagService
    {
        Task<Tag> Create(string name);
    }

    public class TagService : ITagService
    {
        private readonly ITagRepository _repository;

        public TagService(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<Tag> Create(string name)
        {
            try
            {
                if (await TagAlredyExist(name))
                    throw new Exception("Tag já existente.");

                var tag = Tag.New(name);
                await _repository.Insert(tag);

                return tag;
            }
            catch (Exception e) 
            {
                throw new Exception("Falha ao inserir a tag.", e);
            }
        }

        private async Task<bool> TagAlredyExist(string name)
        {
            var tag = await _repository.GetByName(name);
            return tag != null;
        }
    }
}
