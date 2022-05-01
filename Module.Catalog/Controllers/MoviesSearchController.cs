using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities.DTO;
using Module.Catalog.Core.Features.Queries;
using System.Net.Mime;
using System.Text.Json;

namespace Module.Catalog.Controllers;

[ApiController]
[Route("/api/catalog/[controller]")]
public class MoviesSearchController : ControllerBase
{
    private readonly IMediator _mediator;

    public MoviesSearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{movieTitleToSearchFor}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> SearchByTitle(string movieTitleToSearchFor)
    {
        var movies = await _mediator.Send(new SearchMoviesByTitleQuery { MovieTitleToSearchFor = movieTitleToSearchFor });

        if (!movies.Any())
        {
            return NotFound();
        }

        return Ok(movies);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public async Task<IActionResult> SearchExtended(SearchMoviesExtendedQuery query)
    {
        var movies = await _mediator.Send(query);

        if (Response is not null)
        {
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(movies.PaginationMetadata));
        }

        if (!movies.Movies.Any())
        {
            return NotFound();
        }

        return Ok(movies.Movies);
    }
}
