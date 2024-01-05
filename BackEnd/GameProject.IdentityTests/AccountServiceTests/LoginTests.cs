using FluentAssertions;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using GameProject.Identity.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace GameProject.IdentityTests.AccountServiceTests;

public class LoginTests
{
    private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
    private readonly Mock<IJwtService> _mockJwtService;
    public LoginTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null,
            null, null, null, null, null, null);
        _mockJwtService = new Mock<IJwtService>();
    }

    [Fact]
    public async Task Login_GivenNonExistingUser_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(() => null);
        _mockJwtService.Setup(x => x.CreateJwtToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());
        
        IAccountService accountService = new AccountService(_mockUserManager.Object, _mockJwtService.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        response.Description.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Login_GivenIncorrectPasswordForUser_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(false);
        _mockJwtService.Setup(x => x.CreateJwtToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());
        
        IAccountService accountService = new AccountService(_mockUserManager.Object, _mockJwtService.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        response.Description.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task Login_GivenCorrectPasswordForUser_Returns200StatusCode()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(true);
        _mockJwtService.Setup(x => x.CreateJwtToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());
        
        IAccountService accountService = new AccountService(_mockUserManager.Object, _mockJwtService.Object);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await accountService.LoginAsync(loginRequest);

        response.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}