using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Features.Queries;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery { Id = id });

            return Ok(movie);
        }
    }
}
