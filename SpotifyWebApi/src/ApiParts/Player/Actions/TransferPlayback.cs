using System.Text;
using System.Text.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class TransferPlayback(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task Perform(string deviceId)
    {
        StringContent content = new(
            JsonSerializer.Serialize(new { device_ids = new[] { deviceId } }),
            Encoding.UTF8,
            "application/json"
        );

        await _client.PutAsync("me/player", content);
    }
}
