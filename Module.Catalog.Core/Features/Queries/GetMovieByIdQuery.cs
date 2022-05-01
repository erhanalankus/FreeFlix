using MediatR;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities.DTO;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetMovieByIdQuery : IRequest<MovieDTO>
    {
        [Required]
        public int Id { get; set; }
    }

    internal class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieDTO>
    {
        private readonly ICatalogDbContext _context;

        public GetMovieByIdQueryHandler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<MovieDTO> Handle(GetMovieByIdQuery command, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(command.Id);

            if (movie is null)
            {
                return null;
            }
            else
            {
                return new MovieDTO
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Year = movie.Year,
                    Synopsis = movie.Synopsis,
                    Director = movie.Director,
                    Actors = movie.Actors,
                    Genres = movie.Genres
                };
            }
        }
    }
}
