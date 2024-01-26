using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task ChangeAccountData(ChangeAccountDataRequest changeAccountDataRequest)
    {
        var user = await _userManager.FindByEmailAsync(changeAccountDataRequest.Email);
        if (user == null)
        {
            throw new NotFoundException("User with given email was not found");
        }
        user.FirstName = changeAccountDataRequest.FirstName;
        user.LastName = changeAccountDataRequest.LastName;
        user.Country = changeAccountDataRequest.Location;
        user.Platforms = string.Join(';', changeAccountDataRequest.Platforms);
        user.Description = changeAccountDataRequest.Description;
        user.UserName = changeAccountDataRequest.Username;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BadRequestException("Updating of account data was not successfull");
        }
    }

    public async Task ChangeAccountPassword(ChangeAccountPasswordRequest changeAccountPasswordRequest)
    {
        var user = await _userManager.FindByEmailAsync(changeAccountPasswordRequest.Email);
        if (user == null)
        {
            throw new NotFoundException("User with given email does not exist");
        }

        var changePasswordAsync = await _userManager.ChangePasswordAsync(user, changeAccountPasswordRequest.OldPassword,
            changeAccountPasswordRequest.NewPassword);

        if (!changePasswordAsync.Succeeded)
        {
            throw new BadRequestException(string.Join('\n', 
                changePasswordAsync.Errors.Select(err => err.Description)));
        }
    }
}