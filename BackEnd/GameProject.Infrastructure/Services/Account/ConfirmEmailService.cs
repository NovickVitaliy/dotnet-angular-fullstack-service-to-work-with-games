using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace GameProject.Identity.Services.Account;

public class ConfirmEmailService : IConfirmEmailService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly EmailSettings _emailSettings;
    private const string ConfirmationEmailSubject = "Email confirmation";

    public ConfirmEmailService(IOptionsSnapshot<EmailSettings> optionsSnapshotOfEmailSettings, UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
        _emailSettings = optionsSnapshotOfEmailSettings.Value;
    }

    public async Task SendConfirmMessage(SendConfirmEmailMessageRequest sendConfirmEmailMessageRequest)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress(sendConfirmEmailMessageRequest.Email, sendConfirmEmailMessageRequest.Email));
        message.Subject = ConfirmationEmailSubject;
        string confirmEmailToken = await GetEmailConfirmationToken(sendConfirmEmailMessageRequest.Email);

        var callback = QueryHelpers.AddQueryString(sendConfirmEmailMessageRequest.ConfirmUrl, new Dictionary<string, string?>()
        {
            {"token", confirmEmailToken},
            {"email", sendConfirmEmailMessageRequest.Email}
        });
        
        message.Body = new TextPart(TextFormat.Html)
        {
            Text = $"Confirm your email by clicking here: <a href='{callback}'>Confirm</a>"
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    public async Task ConfirmEmail(ConfirmEmailRequest confirmEmailRequest)
    {
        var user = await _userManager.FindByEmailAsync(confirmEmailRequest.Email);

        if (user is null)
        {
            throw new BadRequestException("User does not exist");
        }

        var confirmationResult = await _userManager.ConfirmEmailAsync(user, confirmEmailRequest.ConfirmToken);

        if (!confirmationResult.Succeeded)
        {
            throw new BadRequestException(string.Join('\n', confirmationResult.Errors.Select(err => err.Description)));
        }
    }
 

    private async Task<string> GetEmailConfirmationToken(string userEmail)
    {
        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user is null)
        {
            throw new BadRequestException("User does not exist");
        }

        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }
}