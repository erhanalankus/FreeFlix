using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Features.Commands;
using Moq;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController;

public class UpdateActionShould
{
    [Fact]
    public async void ReturnOkObjectResultIfTheUpdateIsSuccessful()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<UpdateMovieCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.Update(1, new UpdateMovieCommand { Id = 1 });

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void ReturnBadRequestResultIfParametersAreInvalid()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.Update(1, new UpdateMovieCommand { Id = 2 });

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async void NotFoundResultIfThereAreNoMovieWithGivenId()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<UpdateMovieCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(0);
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.Update(1, new UpdateMovieCommand { Id = 1 });

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
