using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class Previous(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task Perform()
    {
        StringContent content = new("");
        await _client.PostAsync("me/player/previous", content);
    }
}
