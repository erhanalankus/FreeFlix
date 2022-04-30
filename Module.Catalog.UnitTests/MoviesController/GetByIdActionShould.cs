using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Features.Queries;
using Moq;
using Shouldly;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController
{
    public class GetByIdActionShould
    {
        [Fact]
        public async void ReturnNotFoundIfThereIsNoMovieWithGivenId()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<GetMovieByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Movie)null);
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.GetById(1);

            // Assert
            result.ShouldBeOfType<NotFoundResult>();
        }

        [Fact]
        public async void ReturnOkResultIfThereIsAMovieWithGivenId()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<GetMovieByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Movie());
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.GetById(1);

            // Assert
            result.ShouldBeOfType<OkObjectResult>();
        }
    }
}
