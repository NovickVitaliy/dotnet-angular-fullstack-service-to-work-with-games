using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Application.Models.Account.ResetPasswordDtos;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Contracts.Emailer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using MimeKit.Text;

namespace GameProject.Identity.Services.Account;

public class ResetPasswordService : IResetPasswordService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IServerEmailer _serverEmailer;
    private const string ResetPasswordSubject = "Password reset";

    public ResetPasswordService(UserManager<ApplicationUser> userManager, IServerEmailer serverEmailer)
    {
        _userManager = userManager;
        _serverEmailer = serverEmailer;
    }

    public async Task SendResetPasswordMail(SendResetPasswordMailRequest sendResetPasswordMailRequest)
    {
        string resetPasswordToken = await GetResetPasswordTokenForUser(sendResetPasswordMailRequest.Email);

        var resetPasswordUrl = QueryHelpers.AddQueryString(sendResetPasswordMailRequest.ResetPasswordUrl,
            new Dictionary<string, string?>()
            {
                { "token", resetPasswordToken },
                { "email", sendResetPasswordMailRequest.Email }
            });

        await _serverEmailer.SendServerEmail(new()
        {
            ReceiverEmail = sendResetPasswordMailRequest.Email,
            ReceiverName = sendResetPasswordMailRequest.Email,
            Subject = ResetPasswordSubject,
            Format = TextFormat.Html,
            Body = resetPasswordUrl
        });
    }

    private async Task<string> GetResetPasswordTokenForUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new BadRequestException("Such user does not exist");
        }

        return await _userManager.GeneratePasswordResetTokenAsync(user);
    }

    public async Task ResetPassword(ResetPasswordRequest resetPasswordRequest)
    {
        var user = await GetUser(resetPasswordRequest.Email);

        var resetPasswordResult =
            await _userManager.ResetPasswordAsync(user, resetPasswordRequest.Token, resetPasswordRequest.NewPassword);

        if (!resetPasswordResult.Succeeded)
        {
            throw new BadRequestException(string.Join('\n', resetPasswordResult.Errors.Select(err => err.Description)));
        }
    }

    private async Task<ApplicationUser> GetUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user == null)
        {
            throw new BadRequestException("Such user does not exist");
        }

        return user;
    }
}