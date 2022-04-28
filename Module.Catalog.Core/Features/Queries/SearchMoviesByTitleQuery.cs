using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Features.Queries;

public class SearchMoviesByTitleQuery : IRequest<IEnumerable<Movie>>
{
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
