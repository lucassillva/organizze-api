using Organizze.Application.UseCases.Tags.Contracts;
using Organizze.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizze.Application.UseCases.Tags
{
    public interface ICreateTagHandler
    {
        Task<TagResponse> Handle(CreateTagRequest request);
    }

    public class CreateTagHandler : ICreateTagHandler
    {
        private readonly ITagService _service;

        public CreateTagHandler(ITagService service)
        {
            _service = service;
        }

        public async Task<TagResponse> Handle(CreateTagRequest request)
        {
            var tag = await _service.Create(request.Name);
            return new TagResponse(tag);
        }
    }
}
