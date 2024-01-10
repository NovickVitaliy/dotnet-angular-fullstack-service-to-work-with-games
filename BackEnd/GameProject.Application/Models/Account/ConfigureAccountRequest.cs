namespace GameProject.Application.Models.Identity;

public class ConfigureAccountRequest
{
    public string Description { get; set; } = string.Empty;
    public DateOnly? DateOfBirth { get; set; }
    public string Country { get; set; } = string.Empty;
    public string[] Platforms { get; set; } = Array.Empty<string>();
}