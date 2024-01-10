using System.Text;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.DbContext;
using GameProject.Identity.Helpers;
using GameProject.Identity.Models;
using GameProject.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GameProject.Identity;

public static class IdentityConfiguration
{
    public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<RefreshTokenSettings>(configuration.GetSection("RefreshTokenSettings"));
        
        services.AddDbContext<ApplicationIdentityDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.ConfigurePasswordOptions();
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ITokenService, IJwtService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(builder =>
            {
                builder.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                };
            });


        return services;
    }
}