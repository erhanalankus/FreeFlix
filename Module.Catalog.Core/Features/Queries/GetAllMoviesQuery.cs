using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {

    }

    internal class MovieQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {
        private readonly ICatalogDbContext _context;

        public MovieQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _context.Movies
                .OrderByDescending(m => m.Year)
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .ToListAsync();

            if (movies == null) throw new Exception("Movies Not Found!");

            return movies;
        }
    }
}
