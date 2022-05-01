using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities.DTO;
using Module.Catalog.Core.Features.Queries;
using Moq;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Module.Catalog.UnitTests.MoviesSearchController;

public class SearchExtendedActionShould
{
    [Fact]
    public async void ReturnOkObjectResultIfMoviesAreFound()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        var movies = new List<MovieDTO>
        {
            new MovieDTO
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
            new MovieDTO
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
        mockMediator
            .Setup(m => m.Send(It.IsAny<SearchMoviesExtendedQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaginatedMoviesDTO
            {
                Movies = movies,
                PaginationMetadata = new PaginationMetadata(10, 1, 3)
            });

        var moviesSearchController = new Controllers.MoviesSearchController(mockMediator.Object);

        var query = new SearchMoviesExtendedQuery
        {
            Page = 1,
            ItemsPerPage = 3,
            Year = "string",
            Title = "string",
            Director = "string",
            Actors = new string[] { "string" },
            Genres = new string[] { "drama" }
        };

        // Act
        var result = await moviesSearchController.SearchExtended(query);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void ReturnNotFoundResultIfNoMoviesAreFound()
    {
        // Arrange
        var mockMediator = new Mock<IMediator>();
        mockMediator
            .Setup(m => m.Send(It.IsAny<SearchMoviesExtendedQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new PaginatedMoviesDTO
            {
                Movies = new List<MovieDTO>(),
                PaginationMetadata = new PaginationMetadata(10, 1, 3)
            });

        var moviesSearchController = new Controllers.MoviesSearchController(mockMediator.Object);

        var query = new SearchMoviesExtendedQuery
        {
            Page = 1,
            ItemsPerPage = 3,
            Year = "string",
            Title = "string",
            Director = "string",
            Actors = new string[] { "string" },
            Genres = new string[] { "drama" }
        };

        // Act
        var result = await moviesSearchController.SearchExtended(query);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}
