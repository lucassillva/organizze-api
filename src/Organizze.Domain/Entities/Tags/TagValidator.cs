using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Domain.Entities.Tags
{
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator() { 
            RuleFor(tag => tag.Name).NotEmpty();
            RuleFor(tag => tag.Name.Length).LessThanOrEqualTo(30);
        }
    }
}
