using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Features.Queries
{
    public class SearchMoviesExtendedQuery : IRequest<IEnumerable<Movie>>
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Director { get; set; }
        public ICollection<string> Genres { get; set; } = new List<string>();
        public ICollection<string> Actors { get; set; } = new List<string>();
    }

    internal class SearchMoviesExtendedQueryHanler : IRequestHandler<SearchMoviesExtendedQuery, IEnumerable<Movie>>
    {
        private readonly ICatalogDbContext _context;

        public SearchMoviesExtendedQueryHanler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> Handle(SearchMoviesExtendedQuery command, CancellationToken cancellationToken)
        {
            var movies = _context.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(command.Title))
            {
                movies = movies.Where(m => m.Title.Contains(command.Title));
            }

            if (!string.IsNullOrWhiteSpace(command.Year))
            {
                movies = movies.Where(m => m.Year == command.Year);
            }

            if (!string.IsNullOrWhiteSpace(command.Director))
            {
                movies = movies.Where(m => m.Director == command.Director);
            }

            if (command.Genres.Any())
            {
                foreach (var genre in command.Genres)
                {
                    movies = movies.Where(m => m.Genres.Contains(genre));
                }
            }

            if (command.Actors.Any())
            {
                foreach (var actor in command.Actors)
                {
                    movies = movies.Where(m => m.Actors.Any(a => a.Contains(actor)));
                }
            }

            return await movies.ToListAsync();
        }
    }
}
