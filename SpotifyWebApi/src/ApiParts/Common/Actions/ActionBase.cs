using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Common.Actions;

public abstract class ActionBase(HttpClientContainer clientContainer) : IAction
{
    protected readonly HttpClient _client = clientContainer.Client;
}
