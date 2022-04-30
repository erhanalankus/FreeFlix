using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {

    }

    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<Movie>>
    {
        private readonly ICatalogDbContext _context;

        public GetAllMoviesQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies.ToListAsync();
        }
    }
}
