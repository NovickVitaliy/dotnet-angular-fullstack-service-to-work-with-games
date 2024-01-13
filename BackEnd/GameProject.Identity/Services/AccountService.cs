using GameProject.Application.Contracts.Account;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Account;
using GameProject.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace GameProject.Identity.Services;

public class AccountService : IAccountService
{
    private UserManager<ApplicationUser> _userManager;

    public AccountService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task EditAccountData(EditAccountDataRequest editAccountDataRequest)
    {
        var user = await _userManager.FindByEmailAsync(editAccountDataRequest.Email);
        if (user == null)
        {
            throw new NotFoundException("User with given email was not found");
        }
        user.FirstName = editAccountDataRequest.FirstName;
        user.LastName = editAccountDataRequest.LastName;
        user.Country = editAccountDataRequest.Location;
        user.Platforms = string.Join(';', editAccountDataRequest.Platforms);
        user.Description = editAccountDataRequest.Description;
        user.UserName = editAccountDataRequest.Username;

        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
        {
            throw new BadRequestException("Updating of account data was not successfull");
        }
    }
}