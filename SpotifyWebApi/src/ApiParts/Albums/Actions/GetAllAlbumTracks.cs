using System.Net.Http.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.ApiParts.Common.Services;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Albums.Actions;

public class GetAllAlbumTracks(HttpClientContainer clientContainer, PaginatedItemsGetter<Track> itemsGetter) : ActionBase(clientContainer)
{
    public async Task<IEnumerable<Track>> Perform(string albumId)
    {
        return await itemsGetter.Perform($"albums/{albumId}/tracks");
    }
}
