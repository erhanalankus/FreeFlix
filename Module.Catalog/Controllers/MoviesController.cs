﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Module.Catalog.Core.Features.Commands;
using Module.Catalog.Core.Features.Queries;

namespace Module.Catalog.Controllers
{
    [ApiController]
    [Route("/api/catalog/[controller]")]
    internal class MoviesController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        //public MoviesController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var movies = await Mediator.Send(new GetAllMoviesQuery());

            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var movie = await Mediator.Send(new GetMovieByIdQuery { Id = id });

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteMovieByIdCommand { Id = id }));
        }
    }
}
