using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Queries;

public class SearchMoviesByTitleQuery : IRequest<IEnumerable<Movie>>
{
    [Required]
    public string SearchQuery { get; set; }
}

internal class SearchMoviesByTitleQueryHandler : IRequestHandler<SearchMoviesByTitleQuery, IEnumerable<Movie>>
{
    private readonly ICatalogDbContext _context;

    public SearchMoviesByTitleQueryHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Movie>> Handle(SearchMoviesByTitleQuery command, CancellationToken cancellationToken)
    {
        var movies = await _context.Movies.Where(m => m.Title.Contains(command.SearchQuery)).ToListAsync();

        return movies;
    }
}
