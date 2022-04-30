﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Catalog.Core.Entities;
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
            .ReturnsAsync(It.IsAny<IEnumerable<Movie>>);
        var moviesSearchController = new Controllers.MoviesSearchController(mockMediator.Object);

        // Act
        var result = await moviesSearchController.Search("string");

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}