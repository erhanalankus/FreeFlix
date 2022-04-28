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
            var moviesList = new List<Movie>();

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

            // HACK: Figure out how to translate this filter to database, also make genre and actor filters case-insensitive
            if (command.Genres.Any() || command.Actors.Any())
            {
                moviesList = await movies.ToListAsync();

                if (command.Genres.Any())
                {
                    foreach (var genre in command.Genres)
                    {
                        moviesList = moviesList.Where(m => m.Genres.Contains(genre)).ToList();
                    }
                }

                if (command.Actors.Any())
                {
                    foreach (var actor in command.Actors)
                    {
                        moviesList = moviesList.Where(m => m.Actors.Contains(actor)).ToList();
                    }
                }

                return moviesList;
            }

            return await movies.ToListAsync();
        }
    }
}
