using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Application.UseCases.Tags.Contracts
{
    public class CreateTagRequest
    {
        public string Name { get; }

        public CreateTagRequest(string name)
        {
            Name = name;
        }
    }
}
