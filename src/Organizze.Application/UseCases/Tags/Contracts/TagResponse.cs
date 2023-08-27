using Organizze.Domain.Entities.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Application.UseCases.Tags.Contracts
{
    public class TagResponse
    {
        public Guid Id { get; }
        public string Name { get; }

        public TagResponse(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
        }
    }
}
