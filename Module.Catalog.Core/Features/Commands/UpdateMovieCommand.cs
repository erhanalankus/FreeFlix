using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Catalog.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Commands;

public class UpdateMovieCommand : IRequest<int>
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Synopsis { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public ICollection<string> Actors { get; set; }
    [Required]
    public ICollection<string> Genres { get; set; }
}

internal class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, int>
{
    private readonly ICatalogDbContext _context;

    public UpdateMovieCommandHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UpdateMovieCommand command, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FindAsync(command.Id);

        if (movie is null)
        {
            return default;
        }
        else
        {
            movie.Title = command.Title;
            movie.Year = command.Year;
            movie.Synopsis = command.Synopsis;
            movie.Director = command.Director;
            movie.Actors = command.Actors;
            movie.Genres = command.Genres;

            var saved = false;

            // This boolean decides on which values win in a concurrency conflict.
            var databaseValuesWin = false;

            while (!saved)
            {
                try
                {
                    await _context.SaveChangesAsync();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException exception)
                {
                    foreach (var movieEntry in exception.Entries)
                    {
                        var proposedValues = movieEntry.CurrentValues;
                        var databaseValues = movieEntry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            proposedValues[property] = databaseValuesWin ? databaseValue : proposedValue;
                        }

                        // Refresh original values to bypass next concurrency check
                        movieEntry.OriginalValues.SetValues(databaseValues);

                        // TODO Inform the user about what happened.
                    }
                }
            }

            return movie.Id;
        }
    }
}
