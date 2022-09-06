using FluentAssertions;
using Inventary.Domain.Enums;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests.Services;

public class SetupServiceTests: IClassFixture<DependencySetupFixture>
{
    private readonly ServiceProvider _serviceProvider;
    
    public SetupServiceTests(DependencySetupFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task GetAllItems_ReturnListSetups()
    {
        // Arrange
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllItems();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<SetupDto>>();
    }

    [Fact]
    public async Task GetAllSetupsWithoutUser_ReturnListSetups()
    {
        // Arrange
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllSetupsWithoutUser();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<SetupDto>>();
    }

    [Fact]
    public async Task GetAllWithNumberOfDefects_ReturnListSetups()
    {
        // Arrange
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllWithNumberOfDefects();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<SetupsListWithNumberOfDefects>>();
    }
    
    [Fact]
    public async Task GetAllSetupsForSelect_ReturnListSetups()
    {
        // Arrange
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllSetupsForSelect();

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<SetupsListForSelect>>();
    }

    [Fact]
    public async Task GetAllSetupsForRoomById_IsValidRoomId_ReturnListSetups()
    {
        // Arrange
        var roomId = new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8");
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetAllSetupsForRoomById(roomId);

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<SetupsListWithNumberOfDefects>>();
    }

    [Fact]
    public async Task GetAllSetupsForRoomById_IsNotValidRoomId_ReturnListSetups()
    {
        // Arrange
        var invalidRoomId = new Guid("854EB322-81AF-4666-9585-D86D510F5B18");
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.GetAllSetupsForRoomById(invalidRoomId));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == "Room is not found");
    }

    [Fact]
    public async Task GetByIdAsync_IsValidSetupId_ReturnSetup()
    {
        // Arrange
        var setupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08");
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var result = await sut.GetByIdAsync(setupId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<SetupDto>();
    }
    
    [Fact]
    public async Task GetByIdAsync_IsNotValidSetupId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidSetupId = new Guid("22EC7BB3-3337-4307-99EA-3461BC52296B");
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<SetupNotFoundException>(() =>
            sut.GetByIdAsync(invalidSetupId));

        // Assert
        exception.Should().NotBeNull().And.Match<SetupNotFoundException>(x =>
            x.Message == $"The setup with the identifier {invalidSetupId} was not found.");
    }

    [Fact]
    public async Task CreateSetup_IsValidModel_ReturnNewSetup()
    {
        // Arrange
        var newSetup = new CreateSetupDto
        {
            SetupName = "New Setup 1",
            Status = StatusEnum.StatusType.Inactive,
            RoomId = null,
            Items = new List<CreateItemWithSetupDto>
            {
                new CreateItemWithSetupDto
                {
                    Id = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88")
                }
            },
            UserId = null
        };
        var sut = GetSetupService(_serviceProvider);
        var oldListSetups = await sut.GetAllItems();
        var itemService = GetItemService(_serviceProvider);
        
        // Act
        var result = await sut.CreateAsync(newSetup);
        var updatedListSetups = await sut.GetAllItems();
        var updatedItem = await itemService.GetByIdAsync(new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"));

        // Assert
        result.Should().NotBeNull().And.BeOfType<SetupDto>();
        updatedListSetups.Should().NotEqual(oldListSetups);
        updatedItem.SetupId.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateAsync_IsValidSetupIdAndValidModel_ReturnTrueAndUpdatedSetupWithItems()
    {
        // Arrange
        var setupId = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1");
        var updatedSetup = new UpdateSetupDto
        {
            Id = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"),
            SetupName = "UpdatedSetup",
            QrCode = "QrCode 2",
            Status = StatusEnum.StatusType.Active,
            RoomId = new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8"),
            Items = new List<CreateItemWithSetupDto>
            {
                new CreateItemWithSetupDto
                {
                    Id = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C")
                }
            },
            UserId = new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D")
        };
        var sut = GetSetupService(_serviceProvider);
        var itemService = GetItemService(_serviceProvider);

        // Act
        var result = await sut.UpdateAsync(setupId, updatedSetup);
        var newUpdatedSetup = await sut.GetByIdAsync(new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"));
        var updatedItem = await itemService.GetByIdAsync(new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C"));
        
        // Assert
        result.Should().BeTrue();
        newUpdatedSetup.SetupName.Should().Be("UpdatedSetup");
        newUpdatedSetup.RoomId.Should().Be(new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8"));
        newUpdatedSetup.UserId.Should().Be(new Guid("336F87B0-8912-4C67-A0CC-D0FA59DEAE3D"));
        updatedItem.SetupId.Should().Be(new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"));
    }

    [Fact]
    public async Task UpdateAsync_IsNotValidSetupId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidSetupId = new Guid("22EC7BB3-3337-4307-99EA-3461BC52296B");
        var updatedSetup = new UpdateSetupDto
        {
            Id = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"),
            SetupName = "UpdatedSetup",
            QrCode = "QrCOde 1",
            Status = StatusEnum.StatusType.Active,
            RoomId = null,
            Items = null,
            UserId = null
        };
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<SetupNotFoundException>(() =>
            sut.UpdateAsync(invalidSetupId, updatedSetup));

        // Assert
        exception.Should().NotBeNull().And.Match<SetupNotFoundException>(x =>
            x.Message == $"The setup with the identifier {invalidSetupId} was not found.");
    }
    
    [Fact]
    public async Task ToggleSetupStatus_IsValidSetupIdAndModel_ReturnTrue()
    {
        // Arrange
        var setupId = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1");
        var movedSetup = new SetupForUpdateStatusDto
        {
            Id = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"),
            SetupName = "UpdatedSetup",
            Status = StatusEnum.StatusType.Active,
            Items = null,
        };
        var sut = GetSetupService(_serviceProvider);

        // Act
        var result = await sut.ToggleSetupStatus(setupId, movedSetup);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task ToggleSetupStatus_IsNotValidSetup_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidSetupId = new Guid("22EC7BB3-3337-4307-99EA-3461BC52296B");
        var movedSetup = new SetupForUpdateStatusDto
        {
            Id = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"),
            SetupName = "UpdatedSetup",
            Status = StatusEnum.StatusType.Active,
            Items = null,
        };
        var sut = GetSetupService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<SetupNotFoundException>(() =>
            sut.ToggleSetupStatus(invalidSetupId, movedSetup));

        // Assert
        exception.Should().NotBeNull().And.Match<SetupNotFoundException>(x =>
            x.Message == $"The setup with the identifier {invalidSetupId} was not found.");
    }

    [Fact]
    public async Task ToggleSetupStatusList_IsValidSetupId_ShouldUpdatedSetupsList()
    {
        // Arrange
        var movedSetup = new SetupForUpdateStatusDto
        {
            Id = new Guid("102813DC-880C-4574-8B77-FC7B662561F9"),
            SetupName = "Setup 5",
            Status = StatusEnum.StatusType.Active,
            Items = null
        };
        var movedSetupList = new List<SetupForUpdateStatusDto>
        {
            movedSetup
        };
        var sut = GetSetupService(_serviceProvider);

        // Act
        await sut.ToggleSetupStatusList(movedSetupList);
        var updatedSetup = await sut.GetByIdAsync(new Guid("102813DC-880C-4574-8B77-FC7B662561F9"));
        
        // Assert
        updatedSetup.Status.Should().Be(StatusEnum.StatusType.Active);

    }

    [Fact]
    public async Task MoveSetupsToAnotherRoom_IsValidRoomIdAndNotEmptyList_ShouldUpdatedSetupListAndItemsList()
    {
        // Arrange
        var movedItem = new ListItemsForUpdate
        {
            Id = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"),
            ItemName = "Item 2"
            
        };
        var movedItemsList = new List<ListItemsForUpdate>
        {
            movedItem
        };
        var movedSetup = new ListMoveSetupsDto
        {
            Id = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08"),
            SetupName = "Setup 1",
            Items = movedItemsList
        };
        var movedSetupList = new List<ListMoveSetupsDto>
        {
            movedSetup
        };
        var roomId = new Guid("080D6BAD-AD9F-443F-A3AE-08C797E66755");
        var setupService = GetSetupService(_serviceProvider);
        var itemService = GetItemService(_serviceProvider);

        // Act
        await setupService.MoveSetupsToAnotherRoom(roomId, movedSetupList);
        var updatedSetup = await setupService.GetByIdAsync(new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08"));
        var updatedItem = await itemService.GetByIdAsync(new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"));

        // Assert
        updatedSetup.RoomId.Should().Be(new Guid("080D6BAD-AD9F-443F-A3AE-08C797E66755"));
        updatedItem.RoomId.Should().Be(new Guid("080D6BAD-AD9F-443F-A3AE-08C797E66755"));
    }

    [Fact]
    public async Task MoveSetupsToAnotherRoom_IsNotValidRoomId_ShouldThrowNotFoundException()
    {
        // Arrange
        var movedSetupList = new List<ListMoveSetupsDto>
        {
           new ListMoveSetupsDto()
        };
        var invalidRoomId = new Guid("631C9FCE-3CA3-4588-8E0C-B8F2B6AA231D");
        var sut = GetSetupService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<RoomNotFoundException>(() =>
            sut.MoveSetupsToAnotherRoom(invalidRoomId, movedSetupList));

        // Assert
        exception.Should().NotBeNull().And.Match<RoomNotFoundException>(x =>
            x.Message == $"The room with the identifier {invalidRoomId} was not found.");
    }

    [Fact]
    public async Task DeleteAsync_IsValidSetupId_ShouldReturnTrueAndChangeNumberOfSetups()
    {
        // Arrange
        var setupId = new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1");
        var sut = GetSetupService(_serviceProvider);
        var oldSetupsList = await sut.GetAllItems();
        
        // Act
        var result = await sut.DeleteAsync(setupId);
        var newSetupsList = await sut.GetAllItems();

        // Assert
        result.Should().BeTrue();
        newSetupsList.Should().NotEqual(oldSetupsList);
    }

    [Fact]
    public async Task DeleteAsync_IsNotValidSetupId_ShouldThrowNotFoundException()
    {
        // Arrange
        var invalidSetupId = new Guid("432FE227-E036-41C5-A41C-5C22117A09E3");
        var sut = GetSetupService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<SetupNotFoundException>(() =>
            sut.DeleteAsync(invalidSetupId));

        // Assert
        exception.Should().NotBeNull().And.Match<SetupNotFoundException>(x =>
            x.Message == $"The setup with the identifier {invalidSetupId} was not found.");
    }
    
    private ISetupService GetSetupService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.SetupService;
    }

    private IItemService GetItemService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.ItemService;
    }
}