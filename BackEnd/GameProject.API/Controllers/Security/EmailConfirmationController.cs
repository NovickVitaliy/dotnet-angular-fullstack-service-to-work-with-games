using GameProject.Application.Contracts.Account;
using GameProject.Application.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers.Security;

[ApiController]
[Route("api/[controller]/[action]")]
public class EmailConfirmationController : ControllerBase
{
    private readonly IConfirmEmailService _confirmEmailService;

    public EmailConfirmationController(IConfirmEmailService confirmEmailService)
    {
        _confirmEmailService = confirmEmailService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> SendConfirmEmailMessage(SendConfirmEmailMessageRequest sendConfirmEmailMessageRequest)
    {
        await _confirmEmailService.SendConfirmMessage(sendConfirmEmailMessageRequest);
        return Ok();
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> ConfirmEmail(ConfirmEmailRequest confirmEmailRequest)
    {
        await _confirmEmailService.ConfirmEmail(confirmEmailRequest);
        return Ok();
    }
}