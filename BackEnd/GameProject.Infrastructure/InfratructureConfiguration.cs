using GameProject.Application.Contracts.Games;
using GameProject.Infrastructure.Games;
using GameProject.Infrastructure.Models.Games;
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
        services.AddHttpClient<IGamesResearcher, GamesResearcher>((provider, client) =>
        {
            var options = provider.GetRequiredService<IOptions<RawgSettings>>();
            client.BaseAddress = new Uri(options.Value.BaseUrl);
        });
        services.Decorate<IGamesResearcher, CachedGamesResearcher>();

        return services;
    }
}