using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        [Required]
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
            return await _context.Movies.FindAsync(command.Id);
        }
    }
}
