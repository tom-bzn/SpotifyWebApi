namespace SpotifyWebApi.Setup;

/// <summary>
/// Created to being utilized by IHttpClientFactory
/// </summary>
public class HttpClientContainer(HttpClient client)
{
    public HttpClient Client { get; } = client;
}
