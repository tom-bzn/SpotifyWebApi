using System.Text;
using System.Text.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class Play(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task Perform(string spotifyUriToPlay)
    {
        StringContent content = new(
            JsonSerializer.Serialize(new { context_uri = spotifyUriToPlay }),
            Encoding.UTF8,
            "application/json"
        );

        await _client.PutAsync("me/player/play", content);
    }
}
