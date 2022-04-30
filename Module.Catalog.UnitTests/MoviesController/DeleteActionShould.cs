using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Features.Commands;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController
{
    public class DeleteActionShould
    {
        [Fact]
        public async void ReturnNotFoundIfThereIsNoMovieWithGivenId()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();            
            mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteMovieByIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(0);
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.Delete(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async void ReturnOkObjectResultIfTheMovieIsDeleted()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<DeleteMovieByIdCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.Delete(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
