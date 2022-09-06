using FluentAssertions;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests.Services;

public class RoomServiceTests : IClassFixture<DependencyRoomsFixture>
{
    private readonly ServiceProvider _serviceProvider;

    public RoomServiceTests(DependencyRoomsFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task GetAllAsync_ReturnListRooms()
    {
        // Arrange
        var sut = GetRoomService(_serviceProvider);

        // Act
        var result = await sut.GetAllAsync();

        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().BeOfType<List<RoomDto>>();
    }

    [Fact]
    public async Task GetByIdAsync_IsValidRoomId_ReturnRoom()
    {
        // Arrange
        var roomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var result = await sut.GetByIdAsync(roomId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<RoomDto>();
    }

    [Fact]
    public async Task GetByIdAsync_IsNotValid_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidRoomId = new Guid("16D76618-BA2B-43B2-8DD3-F0E2120F263F");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<RoomNotFoundException>(() =>
            sut.GetByIdAsync(invalidRoomId));

        // Assert
        exception.Should().NotBeNull().And.Match<RoomNotFoundException>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    [Fact]
    public async Task GetByIdWithCategory_IsValidRoomId_ReturnRoom()
    {
        // Arrange
        var roomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var result = await sut.GetByIdWithCategory(roomId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<List<CategoriesForRoom>>();
    }

    [Fact]
    public async Task GetByIdWithCategory_IsNotValid_ShouldThrowException()
    {
        // Arrange
        var invalidRoomId = new Guid("16D76618-BA2B-43B2-8DD3-F0E2120F263F");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.GetByIdWithCategory(invalidRoomId));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    [Fact]
    public async Task GetByIdWithItems_IsValidRoomId_ReturnRoom()
    {
        // Arrange
        var roomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var result = await sut.GetByIdWithItems(roomId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<List<ItemsForRoom>>();
    }

    [Fact]
    public async Task GetByIdWithItems_IsNotValid_ShouldThrowException()
    {
        // Arrange
        var invalidRoomId = new Guid("16D76618-BA2B-43B2-8DD3-F0E2120F263F");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.GetByIdWithItems(invalidRoomId));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    [Fact]
    public async Task CreateRangeAsync_IsValidModel_ReturnRoom()
    {
        // Arrange
        var listNewRooms = new List<CreateRoomDTO>
        {
            new CreateRoomDTO
            {
                RoomName = "New Room 1"
            },
            new CreateRoomDTO
            {
                RoomName = "New Room 2"
            }
            
        };
        var sut = GetRoomService(_serviceProvider);
        var oldListRooms = await sut.GetAllAsync();
        
        // Act
        var result = await sut.CreateRangeAsync(listNewRooms);
        var updatedListRooms = await sut.GetAllAsync();

        // Assert
        result.Should().BeTrue();
        updatedListRooms.Should().NotEqual(oldListRooms);
    }

    [Fact]
    public async Task UpdateAsync_IsValidRoomIdAndModel_ReturnTrue()
    {
        // Arrange
        var roomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9");
        var room = new CreateRoomDTO
        {
            RoomName = "New Room 2"
        };
        var sut = GetRoomService(_serviceProvider);
        
        // Act
        var result = await sut.UpdateAsync(roomId, room);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task UpdateAsync_IsNotValidRoomId_ShouldThrowNotFoundException()
    {
        var invalidRoomId = new Guid("16D76618-BA2B-43B2-8DD3-F0E2120F263F");
        var sut = GetRoomService(_serviceProvider);
        var room = new CreateRoomDTO
        {
            RoomName = "New Room 1"
        };

        // Act
        var exception = await Assert.ThrowsAsync<RoomNotFoundException>(() =>
            sut.UpdateAsync(invalidRoomId, room));

        // Assert
        exception.Should().NotBeNull().And.Match<RoomNotFoundException>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    [Fact]
    public async Task DeleteAsync_IsValidRoomId_ReturnTrue()
    {
        // Arrange
        var roomId = new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8");
        var sut = GetRoomService(_serviceProvider);
        
        // Act
        var result = await sut.DeleteAsync(roomId);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task DeleteAsync_IsNotValidRoomId_ShouldThrowNotFoundException()
    {
        var invalidRoomId = new Guid("16D76618-BA2B-43B2-8DD3-F0E2120F263F");
        var sut = GetRoomService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<RoomNotFoundException>(() =>
            sut.DeleteAsync(invalidRoomId));

        // Assert
        exception.Should().NotBeNull().And.Match<RoomNotFoundException>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    private IRoomService GetRoomService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.RoomService;
    }
}