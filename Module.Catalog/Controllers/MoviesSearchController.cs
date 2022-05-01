using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Features.Queries;
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
    public async Task<IActionResult> SearchByTitle(string movieTitleToSearchFor)
    {
        var movies = await _mediator.Send(new SearchMoviesByTitleQuery { MovieTitleToSearchFor = movieTitleToSearchFor });

        return Ok(movies);
    }

    [HttpPost]
    public async Task<IActionResult> SearchExtended(SearchMoviesExtendedQuery query)
    {
        var movies = await _mediator.Send(query);

        if (Response is not null)
        {
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(movies.PaginationMetadata));
        }

        return Ok(movies.Movies);
    }
}
