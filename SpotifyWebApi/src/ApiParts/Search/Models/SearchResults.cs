using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.ApiParts.Playlists.Models;

namespace SpotifyWebApi.ApiParts.Search.Models;

public record SearchResults
(
    PaginatedItems<SimplifiedAlbum>? Albums,
    PaginatedItems<SimplifiedPlaylist>? Playlists,
    PaginatedItems<Track>? Tracks
);

// each category will have its own next and prev links (checked on 2025-02-20)
