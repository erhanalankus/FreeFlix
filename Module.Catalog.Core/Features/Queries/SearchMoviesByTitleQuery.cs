using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities.DTO;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Queries;

public class SearchMoviesByTitleQuery : IRequest<IEnumerable<MovieDTO>>
{
    [Required]
    public string SearchQuery { get; set; }
}

internal class SearchMoviesByTitleQueryHandler : IRequestHandler<SearchMoviesByTitleQuery, IEnumerable<MovieDTO>>
{
    private readonly ICatalogDbContext _context;

    public SearchMoviesByTitleQueryHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieDTO>> Handle(SearchMoviesByTitleQuery command, CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.Where(m => m.Title.Contains(command.SearchQuery)).ToListAsync();

        return movies.Select(m => new MovieDTO
        {
            Id = m.Id,
            Title = m.Title,
            Year = m.Year,
            Synopsis = m.Synopsis,
            Director = m.Director,
            Actors = m.Actors,
            Genres = m.Genres
        });
    }
}
