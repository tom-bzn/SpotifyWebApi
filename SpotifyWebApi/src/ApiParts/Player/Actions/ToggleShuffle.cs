using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class ToggleShuffle(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task Perform(bool enableShuffle, string? deviceId = null)
    {
        var uriBuilder = new UriBuilder(new Uri(_client.BaseAddress!, "me/player/shuffle"));

        var query = System.Web.HttpUtility.ParseQueryString(string.Empty);
        query["state"] = enableShuffle ? "true" : "false";
        if (deviceId != null)
        {
            query["device_id"] = deviceId;
        }
        uriBuilder.Query = query.ToString();

        await _client.PutAsync(uriBuilder.Uri, new StringContent(""));
    }
}
