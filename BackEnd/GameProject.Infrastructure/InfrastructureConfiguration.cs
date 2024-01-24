using System.Text;
using GameProject.Application.Contracts.Account;
using GameProject.Application.Contracts.Bussiness;
using GameProject.Application.Contracts.Cloudinary;
using GameProject.Application.Contracts.Games;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Contracts.Persistence;
using GameProject.Application.Contracts.RawgApi.Genres;
using GameProject.Application.Contracts.RawgApi.Platforms;
using GameProject.Application.Models.Identity;
using GameProject.Application.Services;
using GameProject.Identity.Contracts;
using GameProject.Identity.Contracts.Repositories;
using GameProject.Identity.DbContext;
using GameProject.Identity.Helpers;
using GameProject.Identity.Models;
using GameProject.Identity.Repositories;
using GameProject.Identity.Services;
using GameProject.Infrastructure.Cloudinary.Models.Common;
using GameProject.Infrastructure.Cloudinary.Services;
using GameProject.Infrastructure.Games;
using GameProject.Infrastructure.Models.Games;
using GameProject.Infrastructure.RawgApi.Genres;
using GameProject.Infrastructure.RawgApi.Platforms;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GameProject.Identity;

public static class InfrastructureConfiguration
{
    public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<RefreshTokenSettings>(configuration.GetSection("RefreshTokenSettings"));
        
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.ConfigurePasswordOptions();
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ITokenService, IJwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(builder =>
            {
                builder.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"])),
                };
            });

        services.AddAuthorization();

        services.AddScoped<IUserRepository, UserRepository>(); 
        services.AddScoped<IPhotoRepository, PhotoRepository>();

        services.AddScoped<IRepositoryManager, RepositoryManager>();
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


        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IUserGameListService, UserGameListService>();
        return services;
    }
}