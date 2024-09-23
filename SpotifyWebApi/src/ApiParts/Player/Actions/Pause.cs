using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class Pause(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task Perform()
    {
        await _client.PutAsync("me/player/pause", null);
    }
}
