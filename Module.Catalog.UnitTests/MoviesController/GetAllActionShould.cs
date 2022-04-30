using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities;
using Module.Catalog.Core.Features.Queries;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesController
{
    public class GetAllActionShould
    {
        [Fact]
        public async void ReturnNotFoundResultIfThereAreNoMovies()
        {
            // Arrange
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllMoviesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Movie>());
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.GetAllAsync();

            // Assert
            result.ShouldBeOfType<NotFoundResult>();

        }

        [Fact]
        public async void ReturnOkObjectResultIfThereAreMovies()
        {
            // Arrange
            var movies = new List<Movie>
            {
                new Movie
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
                },
                new Movie
                {
                    Id = 2,
                    Title = "Inglourious Basterds",
                    Director = "Quentin Tarantino",
                    Synopsis = "In Nazi-occupied France during World War II, a plan to assassinate Nazi leaders by a group of Jewish U.S. soldiers coincides with a theatre owner's vengeful plans for the same.",
                    Year = "2009",
                    Actors = new List<string>
                    {
                        "Brad Pitt",
                        "Diane Kruger",
                        "Eli Roth"
                    },
                    Genres = new List<string>
                    {
                        "Adventure",
                        "Drama",
                        "War"
                    }
                }
            };
            var mockMediator = new Mock<IMediator>();
            mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllMoviesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(movies);
            var moviesController = new Controllers.MoviesController(mockMediator.Object);

            // Act
            var result = await moviesController.GetAllAsync();

            // Assert
            result.ShouldBeOfType<OkObjectResult>();
        }
    }
}
