using FluentAssertions;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
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
    private readonly Mock<ITokenService> _mockJwtService;

    public LoginTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null,
            null, null, null, null, null, null);
        _mockJwtService = new Mock<ITokenService>();
    }

    [Fact]
    public async Task Login_GivenNonExistingUser_ThrowsNotFoundException()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(() => null);
        _mockJwtService.Setup(x => x.CreateAccessToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());

        IAuthenticationService authenticationService = new AuthenticationService(_mockUserManager.Object, _mockJwtService.Object, null, null);

        Func<Task> action = async () =>
        {
            LoginRequest loginRequest = new LoginRequest();
            BaseResponse<AuthenticationResponse> response = await authenticationService.LoginAsync(loginRequest);
        };

        await action.Should().ThrowExactlyAsync<BadRequestException>();
    }

    [Fact]
    public async Task Login_GivenIncorrectPasswordForUser_ThrowsBadRequestException()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(false);
        _mockJwtService.Setup(x => x.CreateAccessToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());

        IAuthenticationService authenticationService = new AuthenticationService(_mockUserManager.Object, _mockJwtService.Object, null, null);

        Func<Task> action = async () =>
        {
            LoginRequest loginRequest = new LoginRequest();
            BaseResponse<AuthenticationResponse> response = await authenticationService.LoginAsync(loginRequest);
        };

        await action.Should().ThrowExactlyAsync<BadRequestException>();
    }

    [Fact]
    public async Task Login_GivenCorrectPasswordForUser_ReturnsNotNullResponse()
    {
        _mockUserManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>()))
            .ReturnsAsync(new ApplicationUser());
        _mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(),
            It.IsAny<string>())).ReturnsAsync(true);
        _mockJwtService.Setup(x => x.CreateAccessToken(It.IsAny<ApplicationUser>()))
            .Returns(It.IsAny<string>());

        IAuthenticationService authenticationService = new AuthenticationService(_mockUserManager.Object, _mockJwtService.Object, null, null);

        LoginRequest loginRequest = new LoginRequest();
        BaseResponse<AuthenticationResponse> response = await authenticationService.LoginAsync(loginRequest);

        response.Should().NotBeNull();
    }
}