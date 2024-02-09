using System.Security.Claims;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.DbContext;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace GameProject.Identity.IdentityHelpers.InitialAdminCreating;

public static class WebApplicationExtensions
{
    public static void ConfigureInitialAdmin(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationIdentityDbContext>();
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var initialAdminConfiguration =
            serviceScope.ServiceProvider.GetRequiredService<IOptions<InitialAdminConfiguration>>().Value;

        var roleExists = roleManager.RoleExistsAsync(ApplicationRoles.Admin).GetAwaiter().GetResult();

        if (!roleExists)
        {
            roleManager.CreateAsync(new IdentityRole<Guid>() { Name = ApplicationRoles.Admin }).GetAwaiter()
                .GetResult();
        }

        bool adminAlreadyExists = userManager.FindByNameAsync(initialAdminConfiguration.Username).GetAwaiter()
            .GetResult() != null;
        if (!adminAlreadyExists)
        {
            var adminUser = new ApplicationUser()
            {
                UserName = initialAdminConfiguration.Username,
                DateRegistered = DateTime.UtcNow,
                FirstName = initialAdminConfiguration.FirstName ,
                LastName = initialAdminConfiguration.LastName,
                Country = initialAdminConfiguration.Country,
                Platforms = initialAdminConfiguration.Platforms,
                Description = initialAdminConfiguration.Description,
                Email = initialAdminConfiguration.Email,
            };
            userManager.CreateAsync(adminUser,
                initialAdminConfiguration.Password).GetAwaiter().GetResult();

            userManager.AddToRoleAsync(adminUser, ApplicationRoles.Admin).GetAwaiter().GetResult();
        }
    }
}