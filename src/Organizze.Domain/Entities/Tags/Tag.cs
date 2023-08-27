using Organizze.Domain.Repositories.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Domain.Entities.Tags
{
    public class Tag
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly TagValidator _validator;

        internal static Tag New(string name)
        {
            var tag = new Tag(Guid.NewGuid(), name);
            tag.Validate();
            return tag;
        }

        public static Tag Reconstitute(TagData tag)
        {
            return new Tag(tag.Id, tag.Name);
        }

        private Tag(Guid id, string name)
        {
            Id = id;
            Name = name;
            _validator = new TagValidator();
        }

        private void Validate()
        {
            var result = _validator.Validate(this);
            if (result.IsValid is false)
                throw new ArgumentException($"Invalid Tag. Erros: {string.Join(";", result.Errors)}");
        }
    }
}