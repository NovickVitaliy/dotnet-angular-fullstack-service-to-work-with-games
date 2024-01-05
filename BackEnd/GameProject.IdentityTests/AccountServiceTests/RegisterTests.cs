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

public class RegisterTests
{
    private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;

    public RegisterTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null,
            null, null, null, null, null, null);
    }
    
    [Fact]
    public async Task Register_GivenUserWithFreeEmail_ReturnsResponseWith200StatusCode()
    {
        //Arrange
        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(IdentityResult.Success);
        RegisterRequest registerRequest = new RegisterRequest();
        //Act
        IAccountService accountService = new AccountService(_mockUserManager.Object);

        var register = await accountService.RegisterAsync(registerRequest);

        //Assert
        register.StatusCode.Should().Be(200, "because user with free email was given");
    }
    
    [Fact]
    public async Task
        Register_GivenInvalidUserRequest_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(IdentityResult.Failed());

        RegisterRequest registerRequest = new RegisterRequest();

        IAccountService accountService = new AccountService(_mockUserManager.Object);

        BaseResponse<AuthenticationResponse> response = await accountService.RegisterAsync(registerRequest);

        response.Description.Should().NotBeNullOrEmpty("because invalid request was given");
        response.StatusCode.Should().Be(400);
    }
}