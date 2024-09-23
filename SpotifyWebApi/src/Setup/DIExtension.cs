using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SpotifyWebApi.ApiParts.Common;
using SpotifyWebApi.ApiParts.Common.Services;

namespace SpotifyWebApi.Setup;

public static class DIExtension
{
    public static IServiceCollection AddSpotifyWebApi(this IServiceCollection services)
    {
        RegisterActions(services);
        services.AddTransient(typeof(PaginatedItemsGetter<>));

        return services;
    }

    private static void RegisterActions(IServiceCollection services)
    {
        var types = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && t.IsAssignableTo(typeof(IAction)) && !t.IsAbstract);

        foreach (var type in types)
        {
            services.AddTransient(type);
        }
    }
}
