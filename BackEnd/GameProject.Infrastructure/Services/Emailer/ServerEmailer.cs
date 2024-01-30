using GameProject.Identity.Contracts.Emailer;
using GameProject.Identity.Models;
using GameProject.Identity.Models.Emailer;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace GameProject.Identity.Services.Emailer;

public class ServerEmailer : IServerEmailer
{
    private readonly EmailSettings _emailSettings;

    public ServerEmailer(IOptionsSnapshot<EmailSettings> emailOptions)
    {
        _emailSettings = emailOptions.Value;
    }

    public async Task SendServerEmail(ServerEmailMessageRequest serverEmailMessageRequest)
    {
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
        message.To.Add(new MailboxAddress(serverEmailMessageRequest.ReceiverName,
            serverEmailMessageRequest.ReceiverEmail));
        message.Subject = serverEmailMessageRequest.Subject;
        message.Body = new TextPart(serverEmailMessageRequest.Format)
        {
            Text = serverEmailMessageRequest.Body
        };

        using var client = new SmtpClient();
        await client.ConnectAsync(_emailSettings.Server, _emailSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}