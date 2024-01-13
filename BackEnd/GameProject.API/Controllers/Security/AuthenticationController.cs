using System.Security.Claims;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<AuthenticationResponse>>> Register(RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(string.Join('\n',
                ModelState.Values.SelectMany(v => v.Errors)
                    .Select(err => err.ErrorMessage)));
        }

        BaseResponse<AuthenticationResponse> registerResult = await _authenticationService.RegisterAsync(registerRequest);

        return Ok(registerResult);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<AuthenticationResponse>>> Login(LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(string.Join('\n',
                ModelState.Values.SelectMany(v => v.Errors)
                    .Select(err => err.ErrorMessage)));
        }

        BaseResponse<AuthenticationResponse> loginResponse = await _authenticationService.LoginAsync(loginRequest);

        return Ok(loginResponse);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> ConfigureAccount(ConfigureAccountRequest configureAccountRequest)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(string.Join('\n', 
                ModelState.Values.SelectMany(v => v.Errors)
                    .Select(err => err.ErrorMessage)));
        }

        configureAccountRequest.Email = User.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;

        await _authenticationService.ConfigureAccountAsync(configureAccountRequest);

        return NoContent();
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public string Test()
    {
        return "Chel";
    }
}