# SpotifyWebApi

## Description

The library simplifies communication with Spotify Web Api. Written in Net 8.

## Usage

* Get access token (e.g. via SpotifyAuthorize library)
* If you are using ASP.NET Core:
```
// add HttpClient to Service Container (DI)

builder.Services.AddHttpClient<HttpClientContainer>(
    client => HttpClientConfigurator.Configure(client, accessToken)
);

// run other setup actions
builder.Services.AddSpotifyWebApi();
```
* If you are not running ASP.NET, you may want to configure DI manually
* Add specific actions to your methods. Few examples (also from ASP.NET Core)
```
router.MapPut("/next", async (Next action) => await action.Perform());

router.MapPut("/play", async (HttpRequest request, Play action) =>
{
    var reader = new StreamReader(request.Body);
    var spotifyUriToPlay = await reader.ReadToEndAsync();

    await action.Perform(spotifyUriToPlay);
});
```
