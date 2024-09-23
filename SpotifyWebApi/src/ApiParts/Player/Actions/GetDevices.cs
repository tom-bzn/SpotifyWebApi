using System.Data;
using System.Net.Http.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.ApiParts.Player.Models;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Player.Actions;

public class GetDevices(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task<IEnumerable<Device>> Perform()
    {
        var response = await _client.GetFromJsonAsync<DevicesResponse>("me/player/devices") ?? throw new NoNullAllowedException();
        return response.Devices;
    }
}
