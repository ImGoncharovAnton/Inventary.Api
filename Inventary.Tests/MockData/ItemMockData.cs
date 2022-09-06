using Inventary.Domain.Entities;
using Inventary.Domain.Enums;
using Inventary.Repositories.Common.Models;
using Inventary.Services.Models.DTO;

namespace Inventary.Tests.MockData;

public class ItemMockData
{
    public static List<Item> GetItems()
    {
        return new List<Item>
        {
            new Item()
            {
                Id = new Guid("7DE69C2B-1043-4394-81F7-B82EF3645D6C"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ItemName = "Item 1",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 1234.5,
                QRcode = "QrCode 1",
                RoomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9"),
                UserId = null,
                CurrentCategoryId = null,
                SetupId = null
            },
            new Item()
            {
                Id = new Guid("3B0982DD-4540-45F7-82E0-EC4B6E242B88"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ItemName = "Item 2",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 4244.2,
                QRcode = "QrCode 2",
                RoomId = null,
                UserId = null,
                CurrentCategoryId = null,
                SetupId = null
            },
            new Item()
            {
                Id = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ItemName = "Item 3",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 1645.3,
                QRcode = "QrCode 3",
                RoomId = null,
                UserId = null,
                CurrentCategoryId = null,
                SetupId = null
            },
            new Item()
            {
                Id = new Guid("55698B99-96F8-417A-90A4-4303D75506F5"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ItemName = "Notebook 1",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 2335,
                QRcode = "QrCode 4",
                RoomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9"),
                UserId = null,
                CurrentCategoryId = new Guid("B9EA7A35-57C2-4D95-A18D-3C490881A2A2"),
                SetupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08")
            },
            new Item()
            {
                Id = new Guid("4CCAD79E-40BB-4810-9D31-6EFC4E1F3169"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                ItemName = "Notebook 2",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 233,
                QRcode = "QrCode 5",
                RoomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9"),
                UserId = null,
                CurrentCategoryId = new Guid("B9EA7A35-57C2-4D95-A18D-3C490881A2A2"),
                SetupId = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08")
            }
        };
    }

    public static CreateItemDto CreateItemDto()
    {
        return new CreateItemDto
        {
            ItemName = "New Item 1",
            UserDate = DateTime.UtcNow,
            Status = StatusEnum.StatusType.Inactive,
            Price = 4834,
            CurrentCategoryId = new Guid("B9EA7A35-57C2-4D95-A18D-3C490881A2A2")
        };
    }

    public static UpdateItemDto UpdateItemDto()
    {
        return new UpdateItemDto
        {
            Id = new Guid("628A4EE9-E3C7-4B6A-8DCE-6D420B03BC5C"),
            ItemName = "Item 3",
            UserDate = DateTime.UtcNow,
            Status = StatusEnum.StatusType.Inactive,
            Price = 2000,
            QRcode = "QrCode 3",
            RoomId = null,
            UserId = null,
            CurrentCategoryId = null,
            SetupId = null
        };
    }

    public static List<ItemsForRoom> ItemsForRoom()
    {
        return new List<ItemsForRoom>
        {
            new ItemsForRoom
            {
                Id = new Guid("4CCAD79E-40BB-4810-9D31-6EFC4E1F3169"),
                ItemName = "Notebook 2",
                UserDate = DateTime.UtcNow,
                Status = StatusEnum.StatusType.Inactive,
                Price = 233,
                QRcode = "QrCode 5",
                SetupName = "Setup 1",
                CurrentCategoryId = null,
                Defects = null
            }
        };
    }
}