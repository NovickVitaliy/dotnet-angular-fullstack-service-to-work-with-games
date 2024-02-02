using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Identity;

public class LoginRequest : BaseRequest
{
    [Required]
    public string Password { get; set; }
}