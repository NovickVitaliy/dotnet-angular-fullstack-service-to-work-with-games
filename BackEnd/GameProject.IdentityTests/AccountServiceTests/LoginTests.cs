using FluentAssertions;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Models;
using GameProject.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace GameProject.IdentityTests.AccountServiceTests;

public class LoginTests
{
    private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
    
    public LoginTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null,
            null, null, null, null, null, null);
    }

    [Fact]
    public async Task Login_GivenNonExistingUser_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(() => null);

        IAccountService accountService = new AccountService(_mockUserManager.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(400);
        response.Description.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Login_GivenIncorrectPasswordForUser_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(false);

        IAccountService accountService = new AccountService(_mockUserManager.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(400);
        response.Description.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Login_GivenCorrectPasswordForUser_Returns200StatusCode()
    {
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(true);

        IAccountService accountService = new AccountService(_mockUserManager.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(200);
    }
}