namespace SpotifyWebApi.ApiParts.Search.Models.Enum;

[Flags]
public enum SearchTypes
{
    Album = 1 << 0, // 1
    Artist = 1 << 1, // 2
    Playlist = 1 << 2, // 4
    Track = 1 << 3, // 8
    Show = 1 << 4,  // 16
    Episode = 1 << 5,  // 32
    Audiobook = 1 << 6  // 64
}
