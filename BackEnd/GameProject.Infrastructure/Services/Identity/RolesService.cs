using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
using GameProject.Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Services.Identity;

public class RolesService : IRolesService
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public RolesService(RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task AddToRoleAsync(ApplicationUser user, params string[] roles)
    {
        foreach (var role in roles)
        {
            await CreateRolesIfNotExist(role);

            var addToRoleResult = await _userManager.AddToRoleAsync(user, role);

            if (!addToRoleResult.Succeeded)
            {
                throw new BadRequestException(string.Join('\n', addToRoleResult.Errors.Select(err => err.Description)));
            }
        }
    }
    private async Task CreateRolesIfNotExist(params string[] roles)
    {
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                IdentityRole<Guid> newRole = new IdentityRole<Guid>()
                {
                    Name = role
                };

                var roleCreateResult = await _roleManager.CreateAsync(newRole);
                if (!roleCreateResult.Succeeded)
                {
                    throw new BadRequestException("");
                }
            }
        }
    }
}