using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
        
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<AuthenticationResponse>>> Register(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            BaseResponse<AuthenticationResponse> response = new()
            {
                Description = "Bad Request",
                Errors = ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage).ToArray()
            };
            return BadRequest(response);
        }

        BaseResponse<AuthenticationResponse> registerResult = await _accountService.RegisterAsync(registerRequest);

        if (registerResult.StatusCode == StatusCodes.Status200OK)
        {
            return Ok(registerResult);
        }

        return BadRequest(registerResult);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<AuthenticationResponse>>> Login(LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            BaseResponse<AuthenticationResponse> response = new()
            {
                Description = "Bad Request",
                Errors = ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage).ToArray()
            };
            return BadRequest(response);
        }

        BaseResponse<AuthenticationResponse> loginResponse = await _accountService.LoginAsync(loginRequest);
        
        if (loginResponse.StatusCode == StatusCodes.Status200OK)
        {
            return Ok(loginResponse);
        }

        return BadRequest(loginResponse);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<string>> Test()
    {
        return Ok("PEREMOGA");
    }
}