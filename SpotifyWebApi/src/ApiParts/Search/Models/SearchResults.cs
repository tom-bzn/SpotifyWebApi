using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.ApiParts.Playlists.Models;

namespace SpotifyWebApi.ApiParts.Search.Models;

public record SearchResults
(
    PaginatedItems<SimplifiedAlbum>? Albums,
    PaginatedItems<SimplifiedPlaylist>? Playlists
);
