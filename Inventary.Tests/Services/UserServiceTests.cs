using FluentAssertions;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Tests.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests.Services;

public class UserServiceTests: IClassFixture<DependencyUserFixture>
{
    private readonly ServiceProvider _serviceProvider;

    public UserServiceTests(DependencyUserFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task GetAllAsync_ReturnListUsers()
    {
        // Arrange
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllAsync();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<UserDto>>();
    }

    [Fact]
    public async Task GetListUsersForCreateSetup_ReturnListUsers()
    {
        // Arrange
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var result = await sut.GetListUsersForCreateSetup();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<ListUsersForCreateSetup>>();
    }

    [Fact]
    public async Task GetByIdAsync_IsValidUserId_ReturnUser()
    {
        // Arrange
        var userId = new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D");
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var result = await sut.GetByIdAsync(userId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<UserDto>();
    }

    [Fact]
    public async Task GetByIdAsync_IsNotValidUserId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidUserId = new Guid("5C9E6A36-D2DE-4CB8-AC5A-DEB184A635A3");
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            sut.GetByIdAsync(invalidUserId));

        // Assert
        exception.Should().NotBeNull().And.Match<UserNotFoundException>(x =>
            x.Message == $"The user with the identifier {invalidUserId} was not found.");
    }

    [Fact]
    public async Task CreateAsync_ValidModel_ReturnNewUser()
    {
        // Arrange
        var newUser = UserMockData.UserCreateDto();
        var sut = GetUserService(_serviceProvider);
        var oldUsersList = await sut.GetAllAsync();
        var setupService = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.CreateAsync(newUser);
        var newUsersList = await sut.GetAllAsync();
        var updatedSetup = await setupService.GetByIdAsync(new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1"));

        // Assert
        result.Should().NotBeNull().And.BeOfType<UserDto>();
        newUsersList.Should().NotEqual(oldUsersList);
        updatedSetup.UserId.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateAsync_IsValidUserIdAndModel_ReturnTrue()
    {
        // Arrange
        var userId = new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D");
        var newUser = UserMockData.UserCreateDto();
        var sut = GetUserService(_serviceProvider);
        var setupService = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.UpdateAsync(userId, newUser);
        var updatedUser = await sut.GetByIdAsync(userId);
        var updatedSetup = await setupService.GetByIdAsync(new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1"));

        // Assert
        result.Should().BeTrue();
        updatedUser.Email.Should().Be("emal@asd.as");
        updatedUser.Phone.Should().Be("239492-3432");
        updatedUser.FirstName.Should().Be("NewFirstName");
        updatedUser.LastName.Should().Be("NewLastName");
        updatedUser.CurrentSetupId.Should().Be(new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1"));
        updatedSetup.UserId.Should().Be(new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D"));
    }

    [Fact]
    public async Task UpdateAsync_IsNotValidUserId_ShouldThrowNewException()
    {
        // Arrange
        var invalidUserId = new Guid("C547EA68-7396-4B40-BE1C-C1CDC8448C77");
        var newUser = UserMockData.UserCreateDto();
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            sut.UpdateAsync(invalidUserId, newUser));

        // Assert
        exception.Should().NotBeNull().And.Match<UserNotFoundException>(x =>
            x.Message == $"The user with the identifier {invalidUserId} was not found.");
    }

    [Fact]
    public async Task DeleteAsync_IsValidUserId_ReturnTrue()
    {
        // Arrange
        var userId = new Guid("63698479-1A54-49E2-9FBF-34A5003C9148");
        var userService = GetUserService(_serviceProvider);
        var setupService = GetSetupService(_serviceProvider);
        var oldUsersList = await userService.GetAllAsync();
        
        // Act
        var result = await userService.DeleteAsync(userId);
        var newUsersList = await userService.GetAllAsync();
        var updatedSetup = await setupService.GetByIdAsync(new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08"));
        
        // Assert
        result.Should().BeTrue();
        newUsersList.Should().NotEqual(oldUsersList);
        updatedSetup.UserId.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_IsNotValidUserId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidUserId = new Guid("9056AB3A-E7A6-4309-94B4-54CBE907E93D");
        var sut = GetUserService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<UserNotFoundException>(() =>
            sut.DeleteAsync(invalidUserId));

        // Assert
        exception.Should().NotBeNull().And.Match<UserNotFoundException>(x =>
            x.Message == $"The user with the identifier {invalidUserId} was not found.");
    }
    
    private IUserService GetUserService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.UserService;
    }

    private ISetupService GetSetupService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.SetupService;
    }
}