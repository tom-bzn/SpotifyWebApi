using SpotifyWebApi.ApiParts.Common.Models;

namespace SpotifyWebApi.ApiParts.Playlists.Models;

public record SimplifiedPlaylist
(
    string Name,
    string Description,
    string Uri,
    IEnumerable<Image> Images
);

/*
"collaborative": false,      "description": "string",      "external_urls": {        "spotify": "string"      },      "href": "string",      "id": "string",      "images": [        {          "url": "https://i.scdn.co/image/ab67616d00001e02ff9ca10b55ce82ae553c8228",          "height": 300,          "width": 300        }      ],      "name": "string",      "owner": {        "external_urls": {          "spotify": "string"        },        "followers": {          "href": "string",          "total": 0        },        "href": "string",        "id": "string",        "type": "user",        "uri": "string",        "display_name": "string"      },      "public": false,      "snapshot_id": "string",      "tracks": {        "href": "string",        "total": 0      },      "type": "string",      "uri": "string"
*/
