using FluentAssertions;
using Inventary.Domain.Enums;
using Inventary.Repositories;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Contracts;
using Inventary.Services.Extensions;
using Inventary.Services.Infrastructure;
using Inventary.Services.Models.DTO;
using Inventary.Tests.MockData;
using Microsoft.Extensions.DependencyInjection;

namespace Inventary.Tests.Services;

public class ItemServiceTests: IClassFixture<DependencyItemsFixture>
{
    private readonly ServiceProvider _serviceProvider;

    public ItemServiceTests(DependencyItemsFixture fixture)
    {
        _serviceProvider = fixture.ServiceProvider;
    }

    [Fact]
    public async Task GetAllItems_ReturnListAllItems()
    {
        // Arrange
        var sut = GetItemService(_serviceProvider);
    
        // Act
        var result = await sut.GetAllItems();
    
        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().BeOfType<List<ListItemsForStorage>>();
    }

    [Theory]
    [InlineData(1, 3, "itemName_asc", "Item")]
    [InlineData(1, 5, "", "Notebook")]
    public async Task GetItemsByPage_IsValidParameters_ReturnLimitItemsList(int pageIndex, int pageSize, string sortOrderBy, string searchString)
    {
        // Arrange
        var testParameters = new RequestParams
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            SortOrderBy = sortOrderBy,
            SearchString = searchString,
            FilterBySetup = null,
            FilterByRoom = null,
            FilterByCategory = null,
            FilterByStatus = null,
            FilterByDateStart = null,
            FilterByDateEnd = null,
            FilterByPriceStart = null,
            FilterByPriceEnd = null
        };
        var sut = GetItemService(_serviceProvider);

        // Act
        var result = await sut.GetItemsByPage(testParameters);

        // Assert
        result.Should().NotBeNull().And.BeOfType<ListItemsForStorageResponse>();
        result.Items.Should().NotBeNullOrEmpty();
        Assert.All(result.Items, item => Assert.Contains(searchString, item.ItemName));
        result.PageIndex.Should().Be(pageIndex);
        result.PageSize.Should().Be(pageSize);
    }

    [Fact]
    public async Task GetItemsByPage_IsNotValidParameters_ReturnEmptyListItems()
    {
        // Arrange
        var notValidTestParameters = new RequestParams
        {
            PageIndex = -1,
            PageSize = -1,
            SortOrderBy = "",
            SearchString = "ssdfgdjsadw",
            FilterBySetup = null,
            FilterByRoom = null,
            FilterByCategory = null,
            FilterByStatus = null,
            FilterByDateStart = null,
            FilterByDateEnd = null,
            FilterByPriceStart = null,
            FilterByPriceEnd = null
        };
        var sut = GetItemService(_serviceProvider);

        // Act
        var result = await sut.GetItemsByPage(notValidTestParameters);

        // Assert
        result.Should().NotBeNull().And.BeOfType<ListItemsForStorageResponse>();
        result.Items.Should().BeEmpty();
        result.PageIndex.Should().Be(0);
        result.PageSize.Should().Be(0);
    }
    
    [Fact]
    public async Task GetItemsListAsync_ReturnListAllItems()
    {
        // Arrange
        var sut = GetItemService(_serviceProvider);
    
        // Act
        var result = await sut.GetItemsListAsync();
    
        // Assert
        result.Should().NotBeNullOrEmpty();
        result.Should().BeOfType<List<ItemsList>>();
        result.Should().HaveCount(3);
    }

    [Fact]
    public async Task GetItemsListBySetupId_IsValidSetupId_ReturnItemsList()
    {
        // Arrange
        var setupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08");
        var sut = GetItemService(_serviceProvider);

        // Act
        var result = await sut.GetItemsListBySetupId(setupId);

        // Assert
        result.Should().NotBeNullOrEmpty().And.BeOfType<List<ItemsList>>();
        result.Should().HaveCountLessThan(3);
    }
    
    [Fact]
    public async Task GetItemsListBySetupId_IsNotValidSetupId_ShouldThrowException()
    {
        // Arrange
        var setupId = new Guid("304234A4-89F7-4D4C-868A-15CFF2D0CDA9");
        var sut = GetItemService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.GetItemsListBySetupId(setupId));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == "Setup is not found");
    }

    [Fact]
    public async Task GetByIdAsync_IsValidItemId_ReturnItem()
    {
        // Arrange
        var itemId = new Guid("7DE69C2B-1043-4394-81F7-B82EF3645D6C");
        var sut = GetItemService(_serviceProvider);

        // Act
        var result = await sut.GetByIdAsync(itemId);

        // Assert
        result.Should().NotBeNull().And.BeOfType<ItemDto>();
    }
    
    [Fact]
    public async Task GetByIdAsync_IsNotValidItemId_ShouldThrowNotFoundException()
    {
        // Arrange
        var itemId = new Guid("FC8C28D1-CDE3-447C-ABA6-CBC888E8BB61");
        var sut = GetItemService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<ItemNotFoundException>(() =>
            sut.GetByIdAsync(itemId));

        // Assert
        exception.Should().NotBeNull().And.Match<ItemNotFoundException>(x => 
            x.Message == $"The item with the identifier {itemId} was not found.");
    }

    [Fact]
    public async Task CreateAsync_IsValidModel_ReturnItem()
    {
        // Arrange
        var newItem = ItemMockData.CreateItemDto();
        var sut = GetItemService(_serviceProvider);
        
        // Act
        var result = await sut.CreateAsync(newItem);

        // Assert
        result.Should().NotBeNull().And.BeOfType<ItemDto>();
        result.Price.Should().Match(x => x > 0);
        result.ItemName.Should().Match(x => x != string.Empty);
    }

    [Fact]
    public async Task UpdateAsync_IsValidItemIdAndValidModel_ReturnItem()
    {
        // Arrange
        var itemId = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C");
        var item = ItemMockData.UpdateItemDto();
        var sut = GetItemService(_serviceProvider);
        
        // Act
        var result = await sut.UpdateAsync(itemId, item);

        // Assert
        result.Should().NotBeNull().And.BeOfType<ItemDto>();
    }
    
    [Fact]
    public async Task UpdateAsync_NotValidItemId_ShouldThrowNotFoundException()
    {
        // Arrange
        var itemId = new Guid("9736BF37-AD42-41F2-9131-8EA5E29417DC");
        var item = ItemMockData.UpdateItemDto();
        var sut = GetItemService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<ItemNotFoundException>(() =>
            sut.UpdateAsync(itemId, item));

        // Assert
        exception.Should().NotBeNull().And.Match<ItemNotFoundException>(x =>
            x.Message == $"The item with the identifier {itemId} was not found.");
    }

    [Fact]
    public async Task MoveItemsToAnotherRoom_IsValidRoomIdAndNotNullItemsList_ReturnTrue()
    {
        // Arrange
        var roomId = new Guid("FEEF33C2-26FE-47AC-9FB7-17CB5199F3CF");
        var itemsForMove = new List<ListItemsForUpdate>
        {
            new ListItemsForUpdate
            {
                Id = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"),
                ItemName = "Item 2"
            },
            new ListItemsForUpdate
            {
                Id = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C"),
                ItemName = "Item 3"
            }
        };
        var sut = GetItemService(_serviceProvider);
        
        // Act
        var result = await sut.MoveItemsToAnotherRoom(roomId, itemsForMove);

        // Assert
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task MoveItemsToAnotherRoom_IsNotValidRoomIdAndNotNullItemsList_ShouldThrowNotFoundException()
    {
        // Arrange
        var roomId = new Guid("A62E4E0B-0756-452B-B4B3-75DD185556AF");
        var itemsForMove = new List<ListItemsForUpdate>
        {
            new ListItemsForUpdate
            {
                Id = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"),
                ItemName = "Item 2"
            },
            new ListItemsForUpdate
            {
                Id = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C"),
                ItemName = "Item 3"
            }
        };
        var sut = GetItemService(_serviceProvider);
        
        // Act
        var exception = await Assert.ThrowsAsync<RoomNotFoundException>(() =>
            sut.MoveItemsToAnotherRoom(roomId, itemsForMove));

        // Assert
        exception.Should().NotBeNull().And.Match<RoomNotFoundException>(x =>
            x.Message == $"The room with the identifier {roomId} was not found.");
    }
    
    [Fact]
    public async Task MoveItemsToAnotherRoom_IsValidRoomIdAndNullItemsList_ReturnFalse()
    {
        // Arrange
        var roomId = new Guid("FEEF33C2-26FE-47AC-9FB7-17CB5199F3CF");
        var itemsForMove = new List<ListItemsForUpdate>();
        var sut = GetItemService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.MoveItemsToAnotherRoom(roomId, itemsForMove));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == $"List items cannot be empty!");
    }

    [Fact]
    public async Task DeleteAsync_IsValidItemId_ReturnItem()
    {
        // Arrange
        var itemId = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88");
        var sut = GetItemService(_serviceProvider);
        var oldItemsList = await sut.GetAllItems();
        
        // Act
        var result = await sut.DeleteAsync(itemId);
        var newItemsList = await sut.GetAllItems();

        // Assert
        result.Should().NotBeNull().And.BeOfType<ItemDto>();
        newItemsList.Should().NotEqual(oldItemsList);
    }
    
    [Fact]
    public async Task DeleteAsync_IsNotValidItemId_ShouldThrowNotFoundException()
    {
        // Arrange
        var itemId = new Guid("72CF6D6E-426A-4965-8135-FDB12EF3AB0B");
        var sut = GetItemService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<ItemNotFoundException>(() =>
            sut.DeleteAsync(itemId));

        // Assert
        exception.Should().NotBeNull().And.Match<ItemNotFoundException>(x =>
            x.Message == $"The item with the identifier {itemId} was not found.");
        
    }

    [Fact]
    public async Task DeleteRange_IsNotNullListItems_ReturnTrue()
    {
        // Arrange
        var listItemsForDelete = ItemMockData.ItemsForRoom();
        var sut = GetItemService(_serviceProvider);
        var oldListItems = await sut.GetAllItems();
        
        // Act
        var result = await sut.DeleteRange(listItemsForDelete);
        var newListItems = await sut.GetAllItems();

        // Assert
        result.Should().BeTrue();
        newListItems.Should().NotEqual(oldListItems);
    }
    
    [Fact]
    public async Task DeleteRange_IsNullListItems_ReturnTrue()
    {
        // Arrange
        var listItemsForDelete = new List<ItemsForRoom>();
        var sut = GetItemService(_serviceProvider);

        // Act
        var exception = await Assert.ThrowsAsync<Exception>(() =>
            sut.DeleteRange(listItemsForDelete));

        // Assert
        exception.Should().NotBeNull().And.Match<Exception>(x =>
            x.Message == "List items cannot be empty.");

    }
    
    private IItemService GetItemService(IServiceProvider scope)
    {
        return scope.GetService<IServiceManager>()!.ItemService;
    }

}