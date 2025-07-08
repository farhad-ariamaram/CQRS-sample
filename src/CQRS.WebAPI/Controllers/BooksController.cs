using Microsoft.AspNetCore.Mvc;
using CQRS.Application.Books.Commands;
using CQRS.Application.Books.Queries;
using MediatR;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBookCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new {BookId = id});
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllBooksQuery());
            return Ok(result);
        }
    }
}
