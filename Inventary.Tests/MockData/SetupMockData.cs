using Inventary.Domain.Entities;
using Inventary.Domain.Enums;

namespace Inventary.Tests.MockData;

public class SetupMockData
{
    public static List<Setup> GetSetups()
    {
        return new List<Setup>
        {
            new Setup
            {
                Id = new Guid("489FB9AA-471F-41FE-B591-A4C27246BB08"),
                SetupName = "Setup 1",
                QrCode = "QrCode 1",
                Status = StatusEnum.StatusType.Active,
                RoomId = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9"),
                UserId = new Guid("63698479-1A54-49E2-9FBF-34A5003C9148"),
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null,
                User = null
            },
            new Setup
            {
                Id = new Guid("97535E53-44CF-4D9C-A201-DA58B260CFB1"),
                SetupName = "Setup 2",
                QrCode = "QrCode 2",
                Status = StatusEnum.StatusType.Inactive,
                RoomId = null,
                UserId = null, 
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = new List<Item>(),
                User = null
            },
            new Setup
            {
                Id = new Guid("D7179B4A-59A9-4D68-ABCB-7E06D2EB66B1"),
                SetupName = "Setup 3",
                QrCode = "QrCode 3",
                Status = StatusEnum.StatusType.Inactive,
                RoomId = null,
                UserId = null, 
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null,
                User = null
            },
            new Setup
            {
                Id = new Guid("40087030-2A9D-4D15-A8A6-DF78A898BDF4"),
                SetupName = "Setup 4",
                QrCode = "QrCode 4",
                Status = StatusEnum.StatusType.Inactive,
                RoomId = null,
                UserId = null, 
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null,
                User = null
            },
            new Setup
            {
                Id = new Guid("102813DC-880C-4574-8B77-FC7B662561F9"),
                SetupName = "Setup 5",
                QrCode = "QrCode 5",
                Status = StatusEnum.StatusType.Inactive,
                RoomId = new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8"),
                UserId = null, 
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Items = null,
                User = null
            }
        };
    }
}