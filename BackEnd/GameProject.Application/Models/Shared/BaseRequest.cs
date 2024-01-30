using System.ComponentModel.DataAnnotations;

namespace GameProject.Application.Models.Shared;

public class BaseRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}