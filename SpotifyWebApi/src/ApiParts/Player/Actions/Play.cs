using System.Text;
using System.Text.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class Play(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    /// <param name="spotifyUriToPlay">valid uri is album's, playlist's or artist's one</param>
    public async Task Perform(string spotifyUriToPlay)
    {
        await CallApi(new { context_uri = spotifyUriToPlay });
    }

    public async Task Perform(IEnumerable<string> trackUris)
    {
        await CallApi(new { uris = trackUris });
    }

    private async Task CallApi(object bodyToSerialize)
    {
        StringContent content = new(
            JsonSerializer.Serialize(bodyToSerialize),
            Encoding.UTF8,
            "application/json"
        );

        await _client.PutAsync("me/player/play", content);
    }
}
