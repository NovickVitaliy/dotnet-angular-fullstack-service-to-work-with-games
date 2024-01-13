using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameProject.API.Controllers
{
    [Authorize]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> EditAccountData(EditAccountDataRequest editAccountDataRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', 
                    ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage)));
            }

            await _accountService.EditAccountData(editAccountDataRequest);

            return NoContent();
        }
    }
}
