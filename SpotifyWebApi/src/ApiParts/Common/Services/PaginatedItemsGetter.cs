using System.Net.Http.Json;
using SpotifyWebApi.ApiParts.Common.Models;
using SpotifyWebApi.Setup;

namespace SpotifyWebApi.ApiParts.Common.Services;

public class PaginatedItemsGetter<ItemType>(HttpClientContainer clientContainer)
{
    private readonly HttpClient _client = clientContainer.Client;

    public async Task<IEnumerable<ItemType>> Perform(string endpointUri)
    {
        List<ItemType> items = [];

        bool shouldProceed = true;

        while (shouldProceed)
        {
            var results = await _client.GetFromJsonAsync<PaginatedItems<ItemType>>(endpointUri);

            if (null == results)
            {
                break;
            }

            items.AddRange(results.Items);

            if (results.Next == null)
            {
                break;
            }

            endpointUri = results.Next;
        }

        return items;
    }
}
