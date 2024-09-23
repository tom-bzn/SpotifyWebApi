namespace SpotifyWebApi.ApiParts.Common.Models;

public record PaginatedItems<T>
(
    string Href,
    int Limit,
    string? Next,
    int Offset,
    string? Previous,
    int Total,
    IEnumerable<T> Items
);

/*
  "href": "https://api.spotify.com/v1/me/shows?offset=0&limit=20",
  "limit": 20,
  "next": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
  "offset": 0,
  "previous": "https://api.spotify.com/v1/me/shows?offset=1&limit=1",
  "total": 4,
*/