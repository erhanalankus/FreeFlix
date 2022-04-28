﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Features.Queries;

namespace Module.Catalog.Controllers;

[ApiController]
[Route("/api/catalog/[controller]")]
public class MoviesSearchController : ControllerBase
{
    private IMediator _mediator;

    public MoviesSearchController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{searchString}")]
    public async Task<IActionResult> GetById(string searchString)
    {
        var movies = await _mediator.Send(new SearchMoviesByTitleQuery { SearchQuery = searchString });

        return Ok(movies);
    }
}