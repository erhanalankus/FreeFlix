using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities.DTO;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<MovieDTO>>
    {

    }

    internal class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieDTO>>
    {
        private readonly ICatalogDbContext _context;

        public GetAllMoviesQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MovieDTO>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Movies.Select(m => new MovieDTO
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Synopsis = m.Synopsis,
                Director = m.Director,
                Actors = m.Actors,
                Genres = m.Genres
            }).ToListAsync();
        }
    }
}
