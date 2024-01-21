using System.Reflection;
using GameProject.Application.Contracts.Bussiness;
using Microsoft.Extensions.DependencyInjection;

namespace GameProject.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}