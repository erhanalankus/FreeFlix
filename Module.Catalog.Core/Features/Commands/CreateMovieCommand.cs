using MediatR;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;

namespace Module.Catalog.Core.Features.Commands;

public class CreateMovieCommand : IRequest<Movie>
{
    public string Title { get; set; }
    public string Year { get; set; }
    public string Synopsis { get; set; }
    public string Director { get; set; }
    public string[] Actors { get; set; }
    public string[] Genres { get; set; }
}

internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
{
    private readonly ICatalogDbContext _context;

    public CreateMovieCommandHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<Movie> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
    {
        var movieToAdd = new Movie
        {
            Title = command.Title,
            Year = command.Year,
            Synopsis = command.Synopsis,
            Director = command.Director,
            Actors = command.Actors,
            Genres = command.Genres
        };
        _context.Movies.Add(movieToAdd);
        await _context.SaveChangesAsync();

        return movieToAdd;
    }
}
