using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Identity;

public class ConfigureAccountRequest : BaseRequest
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string[] Platforms { get; set; } = Array.Empty<string>();
}