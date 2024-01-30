using System.ComponentModel.DataAnnotations;
using GameProject.Application.Models.Shared;

namespace GameProject.Application.Models.Account;

public class SendConfirmEmailMessageRequest : BaseRequest
{
    [Required] 
    public string ConfirmUrl { get; set; } = string.Empty;
}