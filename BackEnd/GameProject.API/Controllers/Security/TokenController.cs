using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        
        public TokenController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<BaseResponse<TokensModel>>> Refresh(TokensModel tokens)
        {
            return Ok(await _authenticationService.RefreshToken(tokens));
        }
    }
}
