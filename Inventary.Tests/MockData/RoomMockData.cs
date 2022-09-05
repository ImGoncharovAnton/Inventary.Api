using Inventary.Domain.Entities;

namespace Inventary.Tests.MockData;

public class RoomMockData
{
    public static List<Room> GetRooms()
    {
        return new List<Room>()
        {
            new Room
            {
                Id = new Guid("CF1E7791-FA87-4487-8B84-9B8B45CEEEE9"),
                RoomName = "Room 1",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            },
            new Room
            {
                Id = new Guid("FEEF33C2-26FE-47AC-9FB7-17CB5199F3CF"),
                RoomName = "Room 2",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            },
            new Room
            {
                Id = new Guid("080D6BAD-AD9F-443F-A3AE-08C797E66755"),
                RoomName = "Room 3",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            },
            new Room
            {
                Id = new Guid("15CF18BF-0765-485D-B28C-A1A5344D663C"),
                RoomName = "Room 4",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            },
            new Room
            {
                Id = new Guid("640C0DE9-6ED8-43EC-9C4D-9B83A9F923F8"),
                RoomName = "Room 5",
                CreatedDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            }
        };
    }
}