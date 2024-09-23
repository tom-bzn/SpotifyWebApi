using Moq;
using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.ApiParts.Common.Services;
using SpotifyWebApi.Setup;
using SpotifyWebApi.Tests.MockFactories;

namespace SpotifyWebApi.Tests;

public class PaginatedItemsGetterTest
{
    [Fact]
    public async void Perform_UsingIntTypeAndThreePagesThreeItemsPerPage_ReturnsNineItems()
    {
        var clientContainer = new HttpClientContainer(PrepareClientGivingThreePagesPerThreeIntsResults());
        var sut = new PaginatedItemsGetter<int>(clientContainer);

        IEnumerable<int> results = await sut.Perform("http://example.com/ints");

        Assert.Equal(9, results.Count());
    }

    private HttpClient PrepareClientGivingThreePagesPerThreeIntsResults()
    {
        var firstCallResults = new PaginatedItems<int>(
            "http://example.com/ints",
            3,
            "http://example.com/ints?page=2",
            0,
            null,
            9,
            [1, 2, 3]
        );

        var secondCallResults = new PaginatedItems<int>(
            "http://example.com/ints?page=2",
            3,
            "http://example.com/ints?page=3",
            3,
            "http://example.com/ints",
            9,
            [4, 5, 6]
        );

        var thirdCallResults = new PaginatedItems<int>(
            "http://example.com/ints?page=3",
            3,
            null,
            6,
            "http://example.com/ints?page=2",
            9,
            [7, 8, 9]
        );

        var messageHandlerMock = new MessageHandlerFactory().CreateReturningJsonBodyStatusOk(
            [firstCallResults, secondCallResults, thirdCallResults],
            HttpMethod.Get
        );

        return new HttpClient(messageHandlerMock.Object);
    }
}
