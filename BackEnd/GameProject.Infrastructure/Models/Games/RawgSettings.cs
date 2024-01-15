using System.ComponentModel.DataAnnotations;

namespace GameProject.Infrastructure.Models.Games;

public class RawgSettings
{
    [Required]
    public string BaseUrl { get; set; }
    
    [Required]
    public string AuthenticationToken { get; set; }
}