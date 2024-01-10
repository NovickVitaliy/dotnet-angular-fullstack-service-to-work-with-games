namespace GameProject.Identity.Models;

public class RefreshTokenSettings
{
    public const string Key = "RefreshTokenSettings";
    public int RefreshTokenLifeTimeInHours { get; set; }
}