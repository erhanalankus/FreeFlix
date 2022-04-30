using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Features.Commands;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController;

public class CreateActionShould
{
    [Fact]
    public async void ReturnCreatedAtActionResultIfTheMovieIsCreated()
    {
        // Arrange
        var movie = new Movie
        {
            Id = 1,
            Title = "Fight Club",
            Director = "David Fincher",
            Synopsis = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more.",
            Year = "1999",
            Actors = new List<string>
                {
                    "Brad Pitt",
                    "Edward Norton",
                    "Helena Bonham Carter"
                },
            Genres = new List<string>
                {
                    "Drama"
                }
        };
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<CreateMovieCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(movie);
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.Create(new CreateMovieCommand());

        // Assert
        Assert.IsType<CreatedAtActionResult>(result);
    }
}
