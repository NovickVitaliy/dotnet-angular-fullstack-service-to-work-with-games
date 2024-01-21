using GameProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GameProject.Persistence;

public static class PersistenceConfiguration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDatabase>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });


        return services;
    }
}