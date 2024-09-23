namespace SpotifyWebApi.ApiParts.Player.Actions;

public class Pause
{
    public async void Perform(HttpClient client)
    {
        await client.PutAsync("me/player/pause", null);
    }
}
