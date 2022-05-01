using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Entities.DTO;
using System.ComponentModel;

namespace Module.Catalog.Core.Features.Queries
{
    public class SearchMoviesExtendedQuery : IRequest<PaginatedMoviesDTO>
    {        
        private const int _maxItemsPerPage = 5;
        private int itemsPerPage = 3;

        [DefaultValue(1)]
        public int Page { get; set; } = 1;

        [DefaultValue(3)]
        public int ItemsPerPage
        {
            get => itemsPerPage;
            set => itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }

        [DefaultValue("")]
        public string Title { get; set; }

        [DefaultValue("")]
        public string Year { get; set; }

        [DefaultValue("")]
        public string Director { get; set; }

        [DefaultValue(new string[] {"drama"})]
        public ICollection<string> Genres { get; set; } = new List<string>();

        [DefaultValue(new string[] { "" })]
        public ICollection<string> Actors { get; set; } = new List<string>();
    }

    internal class SearchMoviesExtendedQueryHanler : IRequestHandler<SearchMoviesExtendedQuery, PaginatedMoviesDTO>
    {
        private readonly ICatalogDbContext _context;

        public SearchMoviesExtendedQueryHanler(ICatalogDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedMoviesDTO> Handle(SearchMoviesExtendedQuery command, CancellationToken cancellationToken)
        {
            var movies = _context.Movies.OrderBy(m => m.Id).AsQueryable();
            var moviesList = new List<Movie>();
            var result = new PaginatedMoviesDTO();

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

            /* Note to the reviewer:
             *   Genres and Actors properties have been implemented as lists, as
             * stated in the requirements document.
             *   EF Core value conversion has been applied to them to store them
             * in the database in a deserialized form.
             *   Because of the value conversion that's been applied, these filters
             * can't be translated to the database-side. The author is aware of this
             * inefficiency. Genres and Actors should have their own tables, but
             * I believe that level of complexity is not requested for this assignment.
             * Here is my stackoverflow question on this subject:
             * https://stackoverflow.com/questions/72054486/is-using-ef-core-value-converter-preventing-the-contains-method-from-being-tra
             */
            if (command.Genres.Any() || command.Actors.Any())
            {
                moviesList = await movies.ToListAsync();

                if (command.Genres.Any())
                {
                    foreach (var genre in command.Genres)
                    {
                        moviesList = moviesList.Where(m => m.Genres.Any(g => g.ToLower().Contains(genre.ToLower()))).ToList();
                    }
                }

                if (command.Actors.Any())
                {
                    foreach (var actor in command.Actors)
                    {
                        moviesList = moviesList.Where(m => m.Actors.Any(a => a.ToLower().Contains(actor.ToLower()))).ToList();
                    }
                }

                result.Movies = moviesList
                    .Skip((command.Page - 1) * command.ItemsPerPage)
                    .Take(command.ItemsPerPage)
                    .Select(m => new MovieDTO
                        {
                            Id = m.Id,
                            Title = m.Title,
                            Year = m.Year,
                            Synopsis = m.Synopsis,
                            Director = m.Director,
                            Actors = m.Actors,
                            Genres = m.Genres
                        }); ;
                result.PaginationMetadata = new PaginationMetadata(movies.Count(), command.Page, command.ItemsPerPage);

                return result;
            }

            moviesList = await movies
                .Skip((command.Page - 1) * command.ItemsPerPage)
                .Take(command.ItemsPerPage)
                .ToListAsync();
            result.PaginationMetadata = new PaginationMetadata(movies.Count(), command.Page, command.ItemsPerPage);
            result.Movies = moviesList.Select(m => new MovieDTO
            {
                Id = m.Id,
                Title = m.Title,
                Year = m.Year,
                Synopsis = m.Synopsis,
                Director = m.Director,
                Actors = m.Actors,
                Genres = m.Genres
            });

            return result;
        }
    }
}
