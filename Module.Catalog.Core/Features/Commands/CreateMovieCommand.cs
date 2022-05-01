using MediatR;
using Module.Catalog.Core.Abstractions;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Entities.DTO;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Commands;

public class CreateMovieCommand : IRequest<MovieDTO>
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

internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieDTO>
{
    private readonly ICatalogDbContext _context;

    public CreateMovieCommandHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<MovieDTO> Handle(CreateMovieCommand command, CancellationToken cancellationToken)
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
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);

        return new MovieDTO
        {
            Id = movieToAdd.Id,
            Title = movieToAdd.Title,
            Year = movieToAdd.Year,
            Synopsis = movieToAdd.Synopsis,
            Director = movieToAdd.Director,
            Actors = movieToAdd.Actors,
            Genres = movieToAdd.Genres
        };
    }
}
