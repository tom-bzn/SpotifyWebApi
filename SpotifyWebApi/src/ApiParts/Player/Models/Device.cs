namespace SpotifyWebApi.ApiParts.Player.Models;

public record class Device
(
    string Id,
    bool IsActive,
    bool IsPrivateSession,
    bool IsRestricted,
    string Name,
    string Type,
    int VolumePercent,
    bool SupportsVolume
);
