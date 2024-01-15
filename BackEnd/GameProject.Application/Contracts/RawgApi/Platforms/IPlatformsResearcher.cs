using GameProject.Domain.Models;

namespace GameProject.Application.Contracts.RawgApi.Platforms;

public interface IPlatformsResearcher
{
    Task<List<GamingPlatform>> GetAllPlatforms();
}