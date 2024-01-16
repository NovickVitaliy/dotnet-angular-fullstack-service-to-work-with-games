using GameProject.Application.Contracts.Games;
using GameProject.Application.Contracts.RawgApi.Genres;
using GameProject.Application.Contracts.RawgApi.Platforms;
using GameProject.Infrastructure.Games;
using GameProject.Infrastructure.Models.Games;
using GameProject.Infrastructure.RawgApi.Genres;
using GameProject.Infrastructure.RawgApi.Platforms;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GameProject.Infrastructure;

public static class InfratructureConfiguration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.Configure<RawgSettings>(configuration.GetSection("RawgSettings"));
        services.AddHttpClient("RawgClient",(provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<RawgSettings>>();
            client.BaseAddress = new Uri(options.Value.BaseUrl);
        });
        
        services.AddScoped<IGamesResearcher, GamesResearcher>();
        services.Decorate<IGamesResearcher, CachedGamesResearcher>();
        
        services.AddScoped<IPlatformsResearcher, PlatformsResearcher>();
        services.Decorate<IPlatformsResearcher, CachedPlatformsResearcher>();

        services.AddScoped<IGenresResearcher, GenresResearcher>();
        services.Decorate<IGenresResearcher, CachedGenresResearcher>();

        return services;
    }
}