using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.ApiParts.Common.Services;
using SpotifyWebApi.ApiParts.Playlists.Models;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Playlists.Actions;

public class GetAllPlaylistTracks(HttpClientContainer container, PaginatedItemsGetter<PlaylistTrack> itemsGetter) : ActionBase(container)
{
    /// <param name="playlistId">e.g.: 3cEYpjA9oz9GiPac4AsH4n, so, the last part of uri</param>
    public async Task<IEnumerable<Track>> Perform(string playlistId)
    {
        return (await itemsGetter.Perform($"playlists/{playlistId}/tracks")).Select(t => t.Track);
    }
}
