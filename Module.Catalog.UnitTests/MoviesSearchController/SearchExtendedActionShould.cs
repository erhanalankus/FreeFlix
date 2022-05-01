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
    public async void ReturnOkObjectResult()
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
        Assert.IsType<OkObjectResult>(result);
    }
}
