using GameProject.Application.Models.Account;

namespace GameProject.Application.Contracts.Account;

public interface IConfirmEmailService
{
    Task SendConfirmMessage(SendConfirmEmailMessageRequest sendConfirmEmailMessageRequest);
    Task<string> ConfirmEmail(ConfirmEmailRequest confirmEmailRequest);
}