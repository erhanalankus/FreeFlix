using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities.DTO;
using Module.Catalog.Core.Features.Queries;
using Moq;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController;

public class GetByIdActionShould
{
    [Fact]
    public async void ReturnNotFoundResultIfThereIsNoMovieWithGivenId()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<GetMovieByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((MovieDTO)null);
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.GetById(1);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async void ReturnOkObjectResultIfThereIsAMovieWithGivenId()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<GetMovieByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new MovieDTO());
        var moviesController = new Controllers.MoviesController(mockMediator.Object);

        // Act
        var result = await moviesController.GetById(1);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
