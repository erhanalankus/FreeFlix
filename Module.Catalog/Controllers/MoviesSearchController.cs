﻿using MediatR;
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

    [HttpGet("{searchString}")]
    public async Task<IActionResult> Search(string searchString)
    {
        var movies = await _mediator.Send(new SearchMoviesByTitleQuery { SearchQuery = searchString });

        return Ok(movies);
    }

    [HttpPost]
    public async Task<IActionResult> SearchExtended(SearchMoviesExtendedQuery query)
    {
        var movies = await _mediator.Send(query);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(movies.PaginationMetadata));

        return Ok(movies.Movies);
    }
}
