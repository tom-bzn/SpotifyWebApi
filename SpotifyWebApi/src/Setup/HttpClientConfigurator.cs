namespace SpotifyWebApi.Setup;

public static class HttpClientConfigurator
{
    public static void Configure(HttpClient client, string? accessToken = null)
    {
        client.BaseAddress = new Uri("https://api.spotify.com/v1/");
        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }
}
