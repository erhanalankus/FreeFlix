using MediatR;
using Module.Catalog.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Catalog.Core.Features.Commands;

public class UpdateMovieCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Year { get; set; }
    public string Synopsis { get; set; }
    public string Director { get; set; }
    public ICollection<string> Actors { get; set; }
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
            await _context.SaveChangesAsync();

            return movie.Id;
        }
    }
}
