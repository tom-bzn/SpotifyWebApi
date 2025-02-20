namespace SpotifyWebApi.ApiParts.Common.Models;

public interface ISearchableItem
{
    string Name { get; }
    
    IEnumerable<Image>? Images { get; }
    
    string Uri { get; }
}
