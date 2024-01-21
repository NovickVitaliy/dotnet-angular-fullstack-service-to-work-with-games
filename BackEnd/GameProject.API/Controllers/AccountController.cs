using GameProject.Application.Contracts.Account;
using GameProject.Application.Contracts.Cloudinary;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Identity.Contracts.Repositories;
using GameProject.Identity.Extensions;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameProject.API.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IPhotoService _photoService;
    private readonly IUserRepository _userRepository;
    private readonly IPhotoRepository _photoRepository;

    public AccountController(IAccountService accountService, 
        IPhotoService photoService, 
        IUserRepository userRepository, IPhotoRepository photoRepository)
    {
        _accountService = accountService;
        _photoService = photoService;
        _userRepository = userRepository;
        _photoRepository = photoRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ChangeAccountData(ChangeAccountDataRequest changeAccountDataRequest)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(string.Join('\n', 
                ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage)));
        }

        await _accountService.ChangeAccountData(changeAccountDataRequest);

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ChangeAccountPassword(ChangeAccountPasswordRequest changeAccountPasswordRequest)
    {
        if (!ModelState.IsValid)
        {
            throw new BadRequestException(string.Join('\n', 
                ModelState.Values.SelectMany(v => v.Errors).Select(err => err.ErrorMessage)));
        }

        await _accountService.ChangeAccountPassword(changeAccountPasswordRequest);

        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ChangeProfilePhotoResponse>> ChangeAccountProfilePicture([FromForm] IFormFile image)
    {
        var result = await _photoService.AddPhotoAsync(image);

        if (result.Error != null)
        {
            return BadRequest("Image is empty");
        }

        var currentUser = (await _userRepository
            .GetByPredicateAsync(u => u.Email == User.GetUserEmail(), 
                true))
            .Include(u => u.ProfilePhoto)
            .First();
        
        ProfilePhoto profilePhoto = new ProfilePhoto()
        {
            PublicId = result.PublicId,
            Url = result.SecureUrl.AbsoluteUri
        };

        if (currentUser.ProfilePhoto != null)
        {
            await _photoRepository.DeletePhoto(currentUser.ProfilePhoto.Id);
        }
        
        profilePhoto.UserId = currentUser.Id;
        currentUser.ProfilePhoto = profilePhoto;
        await _userRepository.SaveChangesAsync();
        return Ok(new ChangeProfilePhotoResponse(){PhotoUrl = profilePhoto.Url});
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> DeleteAccountProfilePicture()
    {
        var currentUser = (await _userRepository
                .GetByPredicateAsync(u => u.Email == User.GetUserEmail(), 
                    true))
            .Include(u => u.ProfilePhoto)
            .First();

        if (currentUser.ProfilePhoto == null)
        {
            return Ok();
        }

        var deletePhotoResult = await _photoService.DeletePhotoAsync(currentUser.ProfilePhoto.PublicId);

        if (deletePhotoResult.Error != null)
        {
            return BadRequest("Could not delete photo");
        }

        currentUser.ProfilePhoto = null;
        await _userRepository.SaveChangesAsync();

        return Ok();
    }
}