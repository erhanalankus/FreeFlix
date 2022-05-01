using MediatR;
using Module.Catalog.Core.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace Module.Catalog.Core.Features.Commands;

public class DeleteMovieByIdCommand : IRequest<int>
{
    [Required]
    public int Id { get; set; }
}

internal class DeleteMovieByIdCommandHandler : IRequestHandler<DeleteMovieByIdCommand, int>
{
    private readonly ICatalogDbContext _context;

    public DeleteMovieByIdCommandHandler(ICatalogDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(DeleteMovieByIdCommand command, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FindAsync(new object[] { command.Id }, cancellationToken: cancellationToken);

        if (movie is null)
        {
            return default;
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync(cancellationToken: cancellationToken);

        return movie.Id;
    }
}
