using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Contracts.Emailer;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit;
using MimeKit.Text;

namespace GameProject.Identity.Services.Account;

public class ConfirmEmailService : IConfirmEmailService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IServerEmailer _serverEmailer;
    private const string ConfirmationEmailSubject = "Email confirmation";

    public ConfirmEmailService(UserManager<ApplicationUser> userManager, IServerEmailer serverEmailer)
    {
        _userManager = userManager;
        _serverEmailer = serverEmailer;
    }

    public async Task SendConfirmMessage(SendConfirmEmailMessageRequest sendConfirmEmailMessageRequest)
    {
        string confirmEmailToken = await GetEmailConfirmationToken(sendConfirmEmailMessageRequest.Email);

        var confirmUrl = QueryHelpers.AddQueryString(sendConfirmEmailMessageRequest.ConfirmUrl,
            new Dictionary<string, string?>()
            {
                { "token", confirmEmailToken },
                { "email", sendConfirmEmailMessageRequest.Email }
            });

        await _serverEmailer.SendServerEmail(new()
        {
            ReceiverEmail = sendConfirmEmailMessageRequest.Email,
            ReceiverName = sendConfirmEmailMessageRequest.Email,
            Subject = ConfirmationEmailSubject,
            Format = TextFormat.Html,
            Body = $"To confirm your email click here: <a href='{confirmUrl}'>Confirm</a>"
        });
    }

    private async Task<string> GetEmailConfirmationToken(string userEmail)
    {
        var user = await GetUser(userEmail);

        return await _userManager.GenerateEmailConfirmationTokenAsync(user);
    }

    public async Task ConfirmEmail(ConfirmEmailRequest confirmEmailRequest)
    {
        var user = await GetUser(confirmEmailRequest.Email);

        var confirmationResult = await _userManager.ConfirmEmailAsync(user, confirmEmailRequest.ConfirmToken);

        if (!confirmationResult.Succeeded)
        {
            throw new BadRequestException(string.Join('\n', confirmationResult.Errors.Select(err => err.Description)));
        }
    }

    private async Task<ApplicationUser> GetUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new BadRequestException("User does not exist");
        }

        return user;
    }
}