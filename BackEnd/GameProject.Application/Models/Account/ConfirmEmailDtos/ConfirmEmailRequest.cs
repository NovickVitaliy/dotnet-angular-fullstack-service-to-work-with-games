using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account;

public class ConfirmEmailRequest : BaseRequest
{
    [Required]
    public string ConfirmToken { get; set; } = string.Empty;
}