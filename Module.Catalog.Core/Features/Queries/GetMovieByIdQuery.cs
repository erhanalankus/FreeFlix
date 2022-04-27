using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public int Id { get; set; }
    }

    internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private readonly ICatalogDbContext _context;

        public GetMovieByIdQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> Handle(GetMovieByIdQuery command, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == command.Id);

            if (movie == null) throw new Exception("Movie not found!");

            return movie;
        }
    }
}
