using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.ApiParts.Common.Services;
using SpotifyWebApi.ApiParts.Playlists.Models;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Playlists.Actions;

public class GetCurrentUserPlaylists(HttpClientContainer clientContainer, PaginatedItemsGetter<SimplifiedPlaylist> itemsGetter) : ActionBase(clientContainer)
{
    private readonly PaginatedItemsGetter<SimplifiedPlaylist> _itemsGetter = itemsGetter;

    public async Task<IEnumerable<SimplifiedPlaylist>> Perform()
    {
        return await _itemsGetter.Perform("me/playlists");
    }
}
