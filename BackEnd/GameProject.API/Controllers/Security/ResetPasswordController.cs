using GameProject.Application.Contracts.Account;
using GameProject.Application.Models.Account;
using GameProject.Application.Models.Account.ResetPasswordDtos;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers.Security;

[ApiController]
[Route("api/[controller]/[action]")]
public class ResetPasswordController : ControllerBase
{
    private readonly IResetPasswordService _resetPasswordService;

    public ResetPasswordController(IResetPasswordService resetPasswordService)
    {
        _resetPasswordService = resetPasswordService;
    }

    [HttpPost]
    public async Task<ActionResult> SendResetPasswordMail(SendResetPasswordMailRequest sendResetPasswordMailRequest)
    {
        await _resetPasswordService.SendResetPasswordMail(sendResetPasswordMailRequest);
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest)
    {
        await _resetPasswordService.ResetPassword(resetPasswordRequest);
        return Ok();
    }
}