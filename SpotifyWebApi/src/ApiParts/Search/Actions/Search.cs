using System.Data;
using System.Net.Http.Json;
using SpotifyWebApi.ApiParts.Common.Actions;
using SpotifyWebApi.ApiParts.Search.Models;
using SpotifyWebApi.ApiParts.Search.Models.Enum;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Search.Actions;

public class Search(HttpClientContainer clientContainer) : ActionBase(clientContainer)
{
    public async Task<SearchResults> Perform(SearchTypes searchTypes, string query)
    {
        var qs = PrepareQueryString(searchTypes, query);
        return await _client.GetFromJsonAsync<SearchResults>("search?" + qs) ?? throw new NoNullAllowedException();
    }

    private string PrepareQueryString(SearchTypes searchTypes, string query)
    {
        var types = searchTypes.ToString().ToLower().Replace(" ", "");
        return $"q={query}&type={types}";
    }
}
