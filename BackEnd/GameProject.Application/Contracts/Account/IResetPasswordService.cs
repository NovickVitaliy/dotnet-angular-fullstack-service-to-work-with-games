using GameProject.Application.Models.Account;
using GameProject.Application.Models.Account.ResetPasswordDtos;

namespace GameProject.Application.Contracts.Account;

public interface IResetPasswordService
{
    Task SendResetPasswordMail(SendResetPasswordMailRequest sendResetPasswordMailRequest);
    Task ResetPassword(ResetPasswordRequest resetPasswordRequest);
}