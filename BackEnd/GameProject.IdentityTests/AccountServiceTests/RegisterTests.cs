using AutoMapper;
using FluentAssertions;
using GameProject.Application.Common.DTO;
using GameProject.Application.Contracts.Identity;
using GameProject.Application.Exceptions;
using GameProject.Application.Models.Identity;
using GameProject.Domain.Models.Identity;
using GameProject.Identity.Contracts;
using GameProject.Identity.Models;
using GameProject.Identity.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace GameProject.IdentityTests.AccountServiceTests;

public class RegisterTests
{
    private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;
    private readonly Mock<ITokenService> _mockJwtService;
    private readonly Mock<IMapper> _mockMapper;

    public RegisterTests()
    {
        _mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null,
            null, null, null, null, null, null);
        _mockJwtService = new Mock<ITokenService>();
        _mockMapper = new Mock<IMapper>();
    }

    [Fact]
    public async Task Register_GivenUserWithFreeEmail_ReturnsResponseWith200StatusCode()
    {
        //Arrange
        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Success);
        RegisterRequest registerRequest = new RegisterRequest();
        _mockJwtService.Setup(x => x.CreateAccessToken(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(It.IsAny<string>());

        _mockMapper.Setup(x => x.Map<It.IsAnyType>(It.IsAny<ApplicationUser>()));

        IAuthenticationService authenticationService = new AuthenticationService(_mockUserManager.Object, _mockJwtService.Object, null, null, null);

        var register = await authenticationService.RegisterAsync(registerRequest);

        //Assert
        register.Should().NotBeNull();
    }

    [Fact]
    public async Task
        Register_GivenInvalidUserRequest_Returns400StatusCodeAndNotEmptyDescription()
    {
        _mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
            .ReturnsAsync(IdentityResult.Failed(new IdentityError()
                { Code = "ErrorCode", Description = "Error Description" }));

        RegisterRequest registerRequest = new RegisterRequest();
        _mockJwtService.Setup(x => x.CreateAccessToken(It.IsAny<ApplicationUser>()))
            .ReturnsAsync(It.IsAny<string>());

        IAuthenticationService authenticationService = new AuthenticationService(_mockUserManager.Object, _mockJwtService.Object, null, null, null);

        Func<Task> action = async () =>
        {
            BaseResponse<AuthenticationResponse> response = await authenticationService.RegisterAsync(registerRequest);
        };

        await action.Should().ThrowExactlyAsync<BadRequestException>();
    }
}