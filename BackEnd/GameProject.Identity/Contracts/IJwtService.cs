using GameProject.Identity.Models;

namespace GameProject.Identity.Contracts;

public interface IJwtService
{
    string CreateJwtToken(ApplicationUser user);
}