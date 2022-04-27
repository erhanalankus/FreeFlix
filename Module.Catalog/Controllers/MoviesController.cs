using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Queries;

namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _mediator.Send(new GetAllMoviesQuery());

            return Ok(movies);
        }
    }
}
