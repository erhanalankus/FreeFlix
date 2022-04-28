using MediatR;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Commands;

public class CreateMovieCommand : IRequest<Movie>
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Synopsis { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string[] Actors { get; set; }
    [Required]
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
