using SpotifyWebApi.ApiParts.Player.Actions;
using SpotifyWebApi.ApiParts.Player.Models;
using SpotifyWebApi.Setup;
using SpotifyWebApi.Tests.MockFactories;

namespace SpotifyWebApi.Tests;

public class Player_GetDevicesActionTest
{
    [Fact]
    public async void GetDevicesAction_ReadingTwoDevicesFromTheApi_ReturnsTwoDevicesInProperFormat()
    {
        var device1 = new
        {
            id = "555-555-555-555",
            is_active = false,
            is_private_session = false,
            is_restricted = false,
            name = "Living room",
            type = "computer",
            volume_percent = 15,
            supports_volume = true
        };
        var device2 = new
        {
            id = "333-333-333-333",
            is_active = true,
            is_private_session = false,
            is_restricted = false,
            name = "Kitchen",
            type = "computer",
            volume_percent = 33,
            supports_volume = true
        };

        var mockResponse = new
        {
            devices = new List<object> { device1, device2 }
        };

        var messageHandlerMock = new MessageHandlerFactory().CreateReturningJsonBodyStatusOk(mockResponse, HttpMethod.Get);
        var clientContainer = new HttpClientContainer(new HttpClient(messageHandlerMock) { BaseAddress = new Uri("http://example.com") });
        var sut = new GetDevices(clientContainer);

        var devices = await sut.Perform();

        Assert.Equal(2, devices.Count());
        Assert.IsAssignableFrom<IEnumerable<Device>>(devices);
    }
}
