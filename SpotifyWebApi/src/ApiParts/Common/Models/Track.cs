namespace SpotifyWebApi.ApiParts.Common.Models;

public record Track
(
    IEnumerable<SimplifiedArtist> Artists,
    int DurationMs,
    string Href,
    string Name,
    string Id,
    string Uri
);
