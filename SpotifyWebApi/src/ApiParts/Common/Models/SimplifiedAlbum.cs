using SpotifyWebApi.ApiParts.Common.Models.Enums;

namespace SpotifyWebApi.ApiParts.Common.Models;

public record SimplifiedAlbum
(
    AlbumType AlbumType,
    int TotalTracks,
    string Name,
    string ReleaseDate,
    IEnumerable<Image> Images,
    string Uri,
    string Id,
    IEnumerable<SimplifiedArtist> Artists
) : ISearchableItem;
