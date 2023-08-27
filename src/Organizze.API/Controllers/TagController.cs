using Microsoft.AspNetCore.Mvc;
using Organizze.Application.UseCases.Tags;
using Organizze.Application.UseCases.Tags.Contracts;

namespace Organizze.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ICreateTagHandler _createTagHandler;

        public TagController(
            ICreateTagHandler createTagHandler)
        {
            _createTagHandler = createTagHandler;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TagResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest();

            var response = await _createTagHandler.Handle(request);

            return StatusCode(StatusCodes.Status201Created, response);
        }

    }
}
