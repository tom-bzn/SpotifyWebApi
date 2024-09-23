using System.Net;
using System.Net.Http.Json;
using Moq;
using Moq.Protected;

namespace SpotifyWebApi.Tests.MockFactories;

public class MessageHandlerFactory
{
    /// <param name="responseBodies">objects are converted to jsons</param>
    public Mock<HttpMessageHandler> CreateReturningJsonBodyStatusOk(IEnumerable<object> responseBodies, HttpMethod requestMethod)
    {
        var messageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        var sequence = messageHandlerMock.Protected().SetupSequence<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.Is<HttpRequestMessage>(m => m.Method == requestMethod),
            ItExpr.IsAny<CancellationToken>());

        foreach (var responseBody in responseBodies)
        {
            sequence.ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = JsonContent.Create(responseBody)
            });
        }

        return messageHandlerMock;
    }

    public HttpMessageHandler CreateReturningJsonBodyStatusOk(object jsonSerializableResponse, HttpMethod requestMethod)
    {
        var messageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

        var response = new HttpResponseMessage
        {
            StatusCode = HttpStatusCode.OK,
            Content = JsonContent.Create(jsonSerializableResponse)
        };

        messageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(m => m.Method == requestMethod),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(response);

        return messageHandler.Object;
    }
}
