using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities.DTO;
using Module.Catalog.Core.Features.Commands;
using Module.Catalog.Core.Features.Queries;
using System.Net.Mime;

namespace Module.Catalog.Controllers
{
    /*
     * The [ApiController] attribute makes attribute routing a requirement.
     * 
     * The [ApiController] attribute makes model validation errors automatically trigger an HTTP 400 response.
     * Consequently, the following code is unnecessary in an action method:
     * if (!ModelState.IsValid)
     * {
     *     return BadRequest(ModelState);
     * }
     */
    [ApiController]
    [Route("/api/catalog/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await _mediator.Send(new GetAllMoviesQuery());

            if (!movies.Any())
            {
                return NotFound();
            }

            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery { Id = id });

            if (movie is null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteMovieByIdCommand { Id = id });

            if (result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Create(CreateMovieCommand command)
        {
            var createdMovie = await _mediator.Send(command);

            return CreatedAtAction(nameof(MoviesController.GetById), new { id = createdMovie.Id }, createdMovie);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> Update(int id, UpdateMovieCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (result == default)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
