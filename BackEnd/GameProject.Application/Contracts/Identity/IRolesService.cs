using GameProject.Domain.Models.Identity;

namespace GameProject.Application.Contracts.Identity;

public interface IRolesService
{
    public Task AddToRoleAsync(ApplicationUser user, params string[] roles);
}